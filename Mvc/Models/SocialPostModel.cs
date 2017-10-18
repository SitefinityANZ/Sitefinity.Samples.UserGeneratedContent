using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Taxonomies.Model;

namespace Sitefinity.Samples.UserGeneratedContent.Mvc.Models
{
    public class SocialPostModel
    {
        public string Network { get; set; }
        public string ImageUrl { get; set; }
        public string PostUrl { get; set; }
        public DateTime Posted { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public string UserAvatar { get; set; }
        public string UserUrl { get; set; }
        public string UserName { get; set; }
        public Taxon Hashtag { get; set; }
    }
}
