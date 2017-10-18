using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitefinity.Samples.UserGeneratedContent.Models
{
    public class SocialPost
    {
        public string favourite { get; set; }
        public string network { get; set; }
        public string posted { get; set; }
        public string text { get; set; }
        public string lang { get; set; }
        public string sentiment { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public SocialUser user { get; set; }
        public List<SocialUrl> urls { get; set; }
        public List<SocialPopularity> popularity { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public List<SocialUserMention> user_mentions { get; set; }
        public List<SocialTag> tags { get; set; }
    }
}
