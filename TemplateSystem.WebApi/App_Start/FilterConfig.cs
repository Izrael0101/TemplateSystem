using System.Web.Mvc;

namespace TemplateSystem.WebApi.App_Start
{
    /// <summary>
    ///
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}