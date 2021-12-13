using System.Web.Mvc;

namespace TemplateSystem.WebMvc.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HttpError404()
        {
            return View();
        }
    }
}