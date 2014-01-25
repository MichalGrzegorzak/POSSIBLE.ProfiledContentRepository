using System;
using System.Configuration;
using System.Web;
using EPiServer;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StackExchange.Profiling;

namespace POSSIBLE.ProfiledContentRepository
{
    [ModuleDependency(typeof (ServiceContainerInitialization))]
    [InitializableModule]
    public class ContainerInitialisation : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {      
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            if (!ConfigManager.EnableProfiledRepository)
                return;

            context.Container.Configure(x => x.For<IContentRepository>().Use<ProfiledContentRepository>());

            MiniProfiler callEarlyToSetUpRoutes = MiniProfiler.Current;
            MiniProfiler.Settings.MaxJsonResponseSize = 2147483647; //fix json serialization issue
        }
    }

    

}