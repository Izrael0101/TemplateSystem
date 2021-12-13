using NLog;
using System.Web.Mvc;

namespace TemplateSystem.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: Home
        public ActionResult Index()
        {
            try
            {
                logger.Trace("Accedio al Home/Index");
                return View();
            }
            catch (System.Exception)
            {
                logger.Error("Ocurrio un error en el try de Home/Index");
                throw;
            }
        }
    }
}