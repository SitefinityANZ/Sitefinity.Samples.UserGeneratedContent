using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitefinity.Samples.UserGeneratedContent.Models
{
    public class SocialSearchResponse
    {
        public Meta meta { get; set; }
        public List<SocialPost> posts { get; set; }

        public class Meta
        {
            public string period { get; set; }
            public string query_type { get; set; }
            public int http_code { get; set; }
            public string searchid { get; set; }
            public string nextpage { get; set; }
            public string network { get; set; }
            public int limit { get; set; }
            public int page { get; set; }
        }
    }
}
