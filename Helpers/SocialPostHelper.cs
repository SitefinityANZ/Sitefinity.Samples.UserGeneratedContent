using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitefinity.Samples.UserGeneratedContent.Models;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Versioning;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Taxonomies;
using Newtonsoft.Json;
using System.Globalization;
using Telerik.Sitefinity.Data.Linq.Dynamic;

namespace Sitefinity.Samples.UserGeneratedContent.Helpers
{
    public class SocialPostHelper
    {
        internal static void CreatePost(SocialPost item, Taxon taxa)
        {
            try
            {
                var providerName = DynamicModuleManager.GetDefaultProviderName("Telerik.Sitefinity.DynamicTypes.Model.UserGeneratedContent.SocialPost");

                // Set a transaction name and get the version manager
                var transactionName = new Guid().ToString();
                var versionManager = VersionManager.GetManager(null, transactionName);

                DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName, transactionName);
                Type postType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.UserGeneratedContent.SocialPost");

                var itemFilter = String.Format("NetworkUrl = \"{0}\"", item.url);
                var checkItem = dynamicModuleManager.GetDataItems(postType).Where(itemFilter);

                if (checkItem.Count() > 0 || item.image.IsNullOrWhitespace())
                {
                    return;
                }

                dynamicModuleManager.Provider.SuppressSecurityChecks = true;

                DynamicContent socialPostItem = dynamicModuleManager.CreateDataItem(postType);

                // This is how values for the properties are set
                //postItem.SetValue("Title", String.Format("{0}: {1}", item.User.Username, item.Id));
                socialPostItem.SetValue("Title", item.image);
                socialPostItem.SetValue("Text", item.text);
                socialPostItem.SetValue("Network", item.network);
                socialPostItem.SetValue("NetworkUrl", item.url);
                socialPostItem.Organizer.AddTaxa("searchhashtags", taxa.Id);
                socialPostItem.SetValue("SearchId", item.id);
                socialPostItem.SetValue("SocialUser", JsonConvert.SerializeObject(item.user, Formatting.Indented));
                socialPostItem.SetValue("ImageUrl", item.image);
                socialPostItem.SetValue("Highlight", false);
                socialPostItem.SetValue("Type", item.type);

                var posted = DateTime.UtcNow;
                DateTime.TryParseExact(item.posted.Replace("+00000", "").Trim(), "yyyy-MM-dd hh:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out posted);
                //DateTime.TryParseExact(item.posted.Replace("+00000","").Trim(), "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out posted);

                if(posted < DateTime.UtcNow.AddYears(-1))
                {
                    posted = DateTime.UtcNow;
                }

                socialPostItem.SetValue("Posted", posted);

                socialPostItem.SetString("UrlName", Guid.NewGuid().ToString());
                socialPostItem.SetValue("PublicationDate", DateTime.UtcNow);


                socialPostItem.SetWorkflowStatus(dynamicModuleManager.Provider.ApplicationName, "AwaitingApproval");

                // Create a version and commit the transaction in order changes to be persisted to data store
                versionManager.CreateVersion(socialPostItem, false);
                TransactionManager.CommitTransaction(transactionName);

                dynamicModuleManager.Provider.SuppressSecurityChecks = false;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
