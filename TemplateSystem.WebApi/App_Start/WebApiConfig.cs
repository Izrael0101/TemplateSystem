using System.Web.Http;
using TemplateSystem.WebApi.Filters;

namespace TemplateSystem.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new AuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new GlobalExceptionAttribute());
            config.Filters.Add(new LoggingFilterAttribute());
        }
    }
}