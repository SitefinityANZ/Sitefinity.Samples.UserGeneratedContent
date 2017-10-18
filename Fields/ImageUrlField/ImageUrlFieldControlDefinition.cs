using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI.Fields.Definitions;

namespace Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField
{
    public class ImageUrlFieldControlDefinition : FieldControlDefinition, IImageUrlFieldControlDefinition
    {
        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageUrlFieldControlDefinition" /> class.
        /// </summary>
        public ImageUrlFieldControlDefinition() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageUrlFieldControlDefinition" /> class.
        /// </summary>
        /// <param name="configDefinition">The config definition.</param>
        public ImageUrlFieldControlDefinition(ConfigElement configDefinition) : base(configDefinition)
        {
        }
        #endregion

        #region IImageUrlFieldControlDefinition members
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        public string SampleText
        {
            get
            {
                return this.ResolveProperty("SampleText", this.sampleText);
            }
            set
            {
                this.sampleText = value;
            }
        }
        #endregion

        #region Private members
        private string sampleText;
        #endregion
    }
}