using Newtonsoft.Json;
using Sitefinity.Samples.UserGeneratedContent.Configuration;
using Sitefinity.Samples.UserGeneratedContent.Helpers;
using Sitefinity.Samples.UserGeneratedContent.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Scheduling;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;

namespace Sitefinity.Samples.UserGeneratedContent.Tasks
{
    public class HashtagSearchScheduledTask : ScheduledTask
    {
        public HashtagSearchScheduledTask()
        {
            this.Key = HashtagSearchScheduledTask.TaskKey;
        }

        public override string TaskName
        {
            get
            {
                return this.GetType().FullName;
            }
        }

        public override void ExecuteTask()
        {
            SearchSocial();

            if (usgConfig.RunHashtagSearch && !usgConfig.UserKey.IsNullOrWhitespace())
            {
                SchedulingManager schedulingManager = SchedulingManager.GetManager();

                HashtagSearchScheduledTask newTask = new HashtagSearchScheduledTask()
                {
                    ExecuteTime = DateTime.UtcNow.AddMinutes(usgConfig.SearchFrequency).ToUniversalTime()
                };

                schedulingManager.AddTask(newTask);
                schedulingManager.SaveChanges();
            }
        }

        public static void ScheduleTask(DateTime executeTime)
        {
            SchedulingManager schedulingManager = SchedulingManager.GetManager();

            var existingTask = schedulingManager.GetTaskData().FirstOrDefault(x => x.Key == HashtagSearchScheduledTask.TaskKey);

            if (existingTask == null && usgConfig.RunHashtagSearch && !usgConfig.UserKey.IsNullOrWhitespace())
            {
                // Create a new scheduled task
                HashtagSearchScheduledTask newTask = new HashtagSearchScheduledTask()
                {
                    ExecuteTime = executeTime
                };
                schedulingManager.AddTask(newTask);
            }
            else if (usgConfig.RunHashtagSearch && !usgConfig.UserKey.IsNullOrWhitespace())
            {
                // Updates the existing scheduled task
                existingTask.ExecuteTime = executeTime;
            }
            else
            {
                //Delete the task
                schedulingManager.DeleteItem(existingTask);
            }

            SchedulingManager.RescheduleNextRun();
            schedulingManager.SaveChanges();
        }

        private void SearchSocial()
        {
            var reqUrl = "https://api.social-searcher.com/v2/search?q={0}&key={1}&network=twitter,googleplus,instagram&type=photo&limit=40";

            var manager = TaxonomyManager.GetManager();

            var taxonomy = manager.GetTaxonomies<FlatTaxonomy>().Where(t => t.Name == "search-hashtags").Single();

            foreach (var taxa in taxonomy.Taxa)
            {
                var searchResponse = GetSearchResponse(String.Format(reqUrl, taxa.Title.ToString().UrlEncode(), usgConfig.UserKey));

                foreach (var item in searchResponse.posts)
                {
                    SocialPostHelper.CreatePost(item, taxa);
                }
            }
        }

        private SocialSearchResponse GetSearchResponse(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var strsb = reader.ReadToEnd();

                    return JsonConvert.DeserializeObject<SocialSearchResponse>(strsb);
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                return null;
            }
        }

        static UserGeneratedContentConfig usgConfig = Config.Get<UserGeneratedContentConfig>();
        public readonly static string TaskKey = "26f9eff9-4f92-4ba9-bcbd-35e17284213b";
    }
}
