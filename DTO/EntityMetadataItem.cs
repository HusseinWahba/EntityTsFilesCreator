using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTSCreator.DTO
{
    class EntityMetadataItem
    {
        public List<AttributeMetadataItem> Attributes
        {
            get
            {
                if (Metadata.Attributes != null)
                    return new List<AttributeMetadataItem>(Metadata.Attributes.Select(m => new AttributeMetadataItem(m)));
                else
                    return null;
            }
        }
        public EntityMetadata Metadata;
        public bool Selected { get; set; }

        //public bool Selected { get {
        //        return _Selected;
        //    } set {
        //        Selected = _Selected;
        //    }
        //}

        //private bool _Selected;

        public EntityMetadataItem(EntityMetadata _Metadata)
        {
            Metadata = _Metadata;
        }

        //[DisplayName(" \n ")]
        //public bool Selected { get => IsSelected; }

        [DisplayName("Name")]
        public string DisplayName { get => Metadata?.DisplayName?.UserLocalizedLabel?.Label ?? Metadata?.LogicalName; }

        [DisplayName("Logical Name")]
        public string LogicalName { get => Metadata?.LogicalName; }

        [DisplayName("Plural Name")]
        public string PluralName { get => Metadata?.LogicalCollectionName; }

    }
}
