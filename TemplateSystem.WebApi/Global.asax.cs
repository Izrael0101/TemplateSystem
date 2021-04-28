using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TemplateSystem.WebApi.App_Start;

namespace TemplateSystem.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
