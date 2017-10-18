using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitefinity.Samples.UserGeneratedContent.Models.Searches
{
    public class SearchesModel
    {
        public class Meta
        {
            public string query_type { get; set; }
            public int http_code { get; set; }
        }

        public class FacebookPage
        {
            public string name { get; set; }
        }

        public class EmailAlert
        {
            public string started { get; set; }
        }

        public class Monitoring
        {
            public string started { get; set; }
            public int posts_count { get; set; }
            public string start_date { get; set; }
        }

        public class Search
        {
            public string created { get; set; }
            public string changed { get; set; }
            public List<FacebookPage> facebook_pages { get; set; }
            public EmailAlert email_alert { get; set; }
            public string userId { get; set; }
            public Monitoring monitoring { get; set; }
            public string network { get; set; }
            public string q { get; set; }
            public string name { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string status { get; set; }
        }

        public class RootObject
        {
            public Meta meta { get; set; }
            public List<Search> searches { get; set; }
        }
    }
}
