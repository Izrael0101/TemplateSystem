using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateSystem.Entity.Models;
using NLog;

namespace TemplateSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Login()
        {
            logger.Trace("Sample trace message");
            logger.Debug("Sample debug message");
            logger.Info("Sample informational message");
            logger.Warn("Sample warning message");
            logger.Error("Sample error message");
            logger.Fatal("Sample fatal error message");


            LoginModel Mod = new LoginModel();
            return View(Mod);
        }

       // [HttpPost]
        public JsonResult LogInAccess()
        {                       
            try
            {               
                //if(string example)

                var ret = Json(new
                {
                    Result = "OK",
                    url = "Home" + '/' + "Index"

                });

                return ret;
                //}
                //else
                //{
                //    return Json(new { Result = "ERROR", Message = LoginResponse.Message.Message, ChagePass = LoginResponse.Message.MustChangePassword });
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public JsonResult DeleteSession()
        {
            try
            {
               

                var ret = Json(new
                {
                   

                });

                return ret;
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }



        public ActionResult LogOut()
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                //Se elimina el throw ya que no deberia parar la aplicacion en caso de error
                Console.WriteLine(ex.Message);
                return RedirectToAction("Login", "Account");
            }
        }


    }
}
