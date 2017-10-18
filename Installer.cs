using Sitefinity.Samples.UserGeneratedContent.Configuration;
using Sitefinity.Samples.UserGeneratedContent.Tasks;
using System;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;

namespace Sitefinity.Samples.UserGeneratedContent
{
    public static class Installer
    {
        public static void PreApplicationStart()
        {
            Bootstrapper.Initialized += (new EventHandler<ExecutedEventArgs>(Installer.Bootstrapper_Initialized));
        }

        public static void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
                Config.RegisterSection<UserGeneratedContentConfig>();

                InstallVirtualPaths(); // See that method for VIRTUAL PATHS installation code

                HashtagSearchScheduledTask.ScheduleTask(DateTime.UtcNow.AddMinutes(10).ToUniversalTime());
        }

        private static void InstallVirtualPaths()
        {
            SiteInitializer initializer = SiteInitializer.GetInitializer();
            var virtualPathConfig = initializer.Context.GetConfig<VirtualPathSettingsConfig>();

            string key = "~/SitefinitySamplesUserGeneratedContent/*";
            if (!virtualPathConfig.VirtualPaths.ContainsKey(key))
            {
                var newVirtualPathNode = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                {
                    VirtualPath = key,
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = "Sitefinity.Samples.UserGeneratedContent"
                };

                virtualPathConfig.VirtualPaths.Add(newVirtualPathNode);
                Config.GetManager().SaveSection(virtualPathConfig);
            }
        }
    }
}
