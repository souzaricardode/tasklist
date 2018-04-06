using FluentValidation.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskList.Web.AutoMapper;
using Web.App_Start;

namespace TaskList
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InjectionInitialize.Initialize();
            FluentValidationModelValidatorProvider.Configure();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
