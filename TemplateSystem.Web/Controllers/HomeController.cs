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
      
        // GET: Home
        public ActionResult Index()
        {            
            return View();
        }
    }
}