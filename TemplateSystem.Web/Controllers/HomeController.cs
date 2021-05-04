using NLog;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TemplateSystem.Entity.Models;
using TemplateSystem.Services;

namespace TemplateSystem.Web.Controllers
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