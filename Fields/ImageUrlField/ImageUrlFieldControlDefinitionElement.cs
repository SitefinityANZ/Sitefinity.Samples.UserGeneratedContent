using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields.Config;

namespace Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField
{
    public class ImageUrlFieldControlDefinitionElement : FieldControlDefinitionElement, IImageUrlFieldControlDefinition
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageUrlFieldControlDefinitionElement" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public ImageUrlFieldControlDefinitionElement(ConfigElement parent) : base(parent)
        {
        }
        #endregion

        #region FieldControlDefinitionElement members
        public override DefinitionBase GetDefinition()
        {
            return new ImageUrlFieldControlDefinition(this);
        }
        #endregion

        #region IFieldDefinition members
        public override Type DefaultFieldType
        {
            get
            {
                return typeof(ImageUrlFieldControl);
            }
        }
        #endregion

        #region IImageUrlFieldControlDefinition
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        [ConfigurationProperty("SampleText")]
        public string SampleText
        {
            get
            {
                return (string) this["SampleText"];
            }
            set
            {
                this["SampleText"] = value;
            }
        }
        #endregion
    }
}
