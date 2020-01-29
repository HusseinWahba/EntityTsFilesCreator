using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.ComponentModel;

namespace EntityTSCreator.DTO
{
    public class AttributeMetadataItem
    {
        public AttributeMetadataItem(AttributeMetadata _Metadata)
        {
            Metadata = _Metadata;
        }
        public AttributeMetadata Metadata;

        [DisplayName("Name")]
        public string DisplayName => Metadata?.DisplayName?.UserLocalizedLabel?.Label ?? Metadata?.LogicalName;

        [DisplayName("Logical Name")]
        public string LogicalName => Metadata?.LogicalName;

        public AttributeTypeCode? Type => Metadata?.AttributeType;

        public List<PicklistOption> Options
        {
            get
            {
                List<PicklistOption> returnedOptions = new List<PicklistOption>();
                if (Metadata is PicklistAttributeMetadata)
                {
                    var _optionsetMetadata = (PicklistAttributeMetadata)Metadata;
                    for (int i = 0; i < _optionsetMetadata.OptionSet.Options.Count; i++)
                    {
                        returnedOptions.Add(new PicklistOption()
                        {
                            Name = GetTechnicalName(_optionsetMetadata.OptionSet.Options[i].Label.UserLocalizedLabel.Label),
                            Value = _optionsetMetadata.OptionSet.Options[i].Value.Value
                        });
                    }
                }
                return returnedOptions;
            }
        }

        string GetTechnicalName(string displayName)
        {
            string returnedName = displayName.Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace(".", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace("'", "")
                .Replace("*", "")
                .Replace("&", "")
                .Replace("%", "")
                .Replace("-", "_")
                .Replace("+", "_")
                .Replace("/", "_")
                .Replace("\\", "_")
                .Replace("[", "_")
                .Replace("]", "_");

            returnedName = moveNumbersToEnd(returnedName);

            return returnedName;
        }

        string moveNumbersToEnd(string name)
        {
            string returnedValue = name;
            if (char.IsDigit(name[0]))
            {
                returnedValue = name.Substring(1, name.Length - 1) + name[0];
            }
            if (char.IsDigit(returnedValue[0]))
                return moveNumbersToEnd(returnedValue);
            return returnedValue;
        }
    }

    public class PicklistOption
    {
        public int Value;
        public string Name;
    }
}