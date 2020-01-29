using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using EntityTSCreator.DTO;
using System.IO;

namespace EntityTSCreator
{
    public partial class MyPluginControl : PluginControlBase
    {
        #region Private Fields
        private List<EntityMetadataItem> entities;

        #endregion

        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            //TODO know the reason
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetMetadata);
            //ExecuteMethod(GetAccounts);
        }

        private void FilterEntities()
        {
            if (entities != null && entities.Count > 0)
            {


                if (!string.IsNullOrEmpty(tbSeachEntity.Text))
                    gridEntities.DataSource = entities.Where(x => x.LogicalName.Contains(tbSeachEntity.Text)).ToList();
                else
                    gridEntities.DataSource = entities;
                gridEntities.ReadOnly = false;

            }
            else
            {
                gridEntities.DataSource = null;
            }
        }

        private void GetMetadata()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting metadata",
                Work = (worker, args) =>
                {
                    RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
                    //metaDataRequest.EntityFilters = EntityFilters.All;
                    RetrieveAllEntitiesResponse metaDataResponse = new RetrieveAllEntitiesResponse();
                    metaDataRequest.EntityFilters = EntityFilters.Entity;

                    // Execute the request.

                    metaDataResponse = (RetrieveAllEntitiesResponse)Service.Execute(metaDataRequest);

                    args.Result = metaDataResponse.EntityMetadata;

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    var result = args.Result as EntityMetadata[];
                    if (result != null)
                    {
                        entities = new List<EntityMetadataItem>(
                            result
                                .Select(m => new EntityMetadataItem(m))
                                .OrderBy(e => e.ToString()));
                        FilterEntities();
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterEntities();
        }

        private void gridEntities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting single entity metadata",
                Work = (worker, args) =>
                {
                    if (gridEntities.SelectedRows.Count > 0)
                    {
                        var currentRow = gridEntities.SelectedRows[0];
                        var entity = ((EntityMetadataItem)currentRow.DataBoundItem);

                        if (entity.Attributes == null)
                        {
                            RetrieveEntityRequest entityMetaDataReq = new RetrieveEntityRequest() { LogicalName = entity.LogicalName };
                            entityMetaDataReq.EntityFilters = EntityFilters.Attributes;
                            var entityResponse = (RetrieveEntityResponse)Service.Execute(entityMetaDataReq);

                            entity.Metadata = entityResponse.EntityMetadata;
                            //args.Result = entity.Attributes;

                        }
                        args.Result = entity.Attributes;

                    }

                },
                PostWorkCallBack = (args) =>
                {
                    gridAttributes.DataSource = args.Result;
                }
            });


        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            var fldr = new FolderBrowserDialog
            {
                Description = "Select folder where generated constant files will be generated.",
                SelectedPath = txtOutputFolder.Text,
                ShowNewFolderButton = true
            };
            if (fldr.ShowDialog(this) == DialogResult.OK)
            {
                txtOutputFolder.Text = fldr.SelectedPath;
            }
        }

        private void tsbGenerate_Click(object sender, EventArgs e)
        {
            ExecuteMethod(tsbGenerateMethof);
            
        }

        private void tsbGenerateMethof()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Generating entities",
                Work = (worker, args) =>
                {
                    string generatedClass = "";
                    for (int i = 0; i < gridEntities.Rows.Count; i++)
                    {
                        var gridItem = gridEntities.Rows[i].DataBoundItem as EntityMetadataItem;
                        if (gridItem.Selected)
                        {
                            string fieldType = "";
                            generatedClass += "export class " + gridItem.LogicalName + " {\r\n";
                            var optionsetsFields = new List<AttributeMetadataItem>();
                            for (int j = 0; j < gridItem.Attributes.Count; j++)
                            {
                                if (gridItem.Attributes[j].Type == AttributeTypeCode.Decimal
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.Double
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.Integer
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.Money
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.BigInt)
                                {
                                    fieldType = "number";
                                }
                                else if (gridItem.Attributes[j].Type == AttributeTypeCode.Boolean)
                                {
                                    fieldType = "boolean";
                                }
                                else if (gridItem.Attributes[j].Type == AttributeTypeCode.Memo
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.String
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.EntityName)
                                {
                                    fieldType = "string";
                                }
                                else if (gridItem.Attributes[j].Type == AttributeTypeCode.DateTime)
                                {
                                    fieldType = "Date";
                                }
                                else if (gridItem.Attributes[j].Type == AttributeTypeCode.Customer
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.Uniqueidentifier
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.Lookup
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.Owner)
                                {
                                    fieldType = "string";
                                }
                                else if (gridItem.Attributes[j].Type == AttributeTypeCode.Picklist
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.State
                                    || gridItem.Attributes[j].Type == AttributeTypeCode.Status)
                                {
                                    fieldType = gridItem.Attributes[j].LogicalName + "Enum";
                                    optionsetsFields.Add(gridItem.Attributes[j]);
                                }

                                if (!string.IsNullOrEmpty(fieldType))
                                    generatedClass += "\t" + gridItem.Attributes[j].LogicalName + ": " + fieldType + ";\r\n";
                            }
                            generatedClass += "}\r\n";

                            for (int k = 0; k < optionsetsFields.Count; k++)
                            {
                                string enumString = "export enum " + optionsetsFields[k].LogicalName + "Enum {\r\n";
                                for (int l = 0; l < optionsetsFields[k].Options.Count; l++)
                                {
                                    enumString += "\t" + optionsetsFields[k].Options[l].Name + " = " + optionsetsFields[k].Options[l].Value;
                                    if (l == optionsetsFields[k].Options.Count - 1)
                                    {
                                        enumString += "\r\n";
                                    }
                                    else
                                    {
                                        enumString += ",\r\n";
                                    }
                                }
                                generatedClass += enumString + "}\r\n";
                            }

                            File.WriteAllText(txtOutputFolder.Text + "/" + gridItem.LogicalName + ".ts", generatedClass);
                        }
                    }
                },
                PostWorkCallBack = (args) =>
                {

                }
            });
        }

        private void gridEntities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridEntities.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}