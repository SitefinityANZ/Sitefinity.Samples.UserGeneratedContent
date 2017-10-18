using System;
using System.Linq;
using Telerik.Sitefinity.Web.UI.Fields.Contracts;

namespace Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField
{
    public interface IImageUrlFieldControlDefinition : IFieldControlDefinition
    {
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        /// <value>The sample text.</value>
        string SampleText { get; set; }
    }
}
