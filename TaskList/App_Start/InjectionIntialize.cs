using MvcSiteMapProvider.Loader;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using TaskList.Web;

namespace Web.App_Start
{
    public static class InjectionInitialize
    {
        public static Container Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            InitializeMvcSiteMapProvider(container);
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }

        private static void InitializeContainer(Container container)
        {
            TaskList.IOC.Bootstrap.RegistrarServicos(container);
        }

        private static void InitializeMvcSiteMapProvider(Container container)
        {
            //Todo: rever
            MvcSiteMapProviderContainerInitializer.SetUp(container);
            MvcSiteMapProvider.SiteMaps.Loader = container.GetInstance<ISiteMapLoader>();
        }
    }
}