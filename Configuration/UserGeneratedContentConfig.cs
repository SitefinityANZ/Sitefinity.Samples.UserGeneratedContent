using System.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace Sitefinity.Samples.UserGeneratedContent.Configuration
{
    [ObjectInfo(Title = "UserGeneratedContent", Description = "User Generated Content")]
    public class UserGeneratedContentConfig : ConfigSection
    {
        [ObjectInfo(Title = "SearchFrequency", Description = "The frequency in which to run the hashtag search(in minutes).")]
        [ConfigurationProperty("SearchFrequency", DefaultValue = 15)]
        public int SearchFrequency
        {
            get
            {
                return (int) this["SearchFrequency"];
            }
            set
            {
                this["SearchFrequency"] = value;
            }
        }

        [ObjectInfo(Title = "RunHashtagSearch", Description = "Should the hashtag search run")]
        [ConfigurationProperty("RunHashtagSearch", DefaultValue = false)]
        public bool RunHashtagSearch
        {
            get
            {
                return (bool) this["RunHashtagSearch"];
            }
            set
            {
                this["RunHashtagSearch"] = value;
            }
        }

        [ObjectInfo(Title = "UserKey")]
        [ConfigurationProperty("UserKey")]
        public string UserKey
        {
            get
            {
                return (string) this["UserKey"];
            }
            set
            {
                this["UserKey"] = value;
            }
        }
    }
}
