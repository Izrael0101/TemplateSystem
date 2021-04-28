using System.Net;
using System.Web.Http;
using TemplateSystem.WebApi.Helpers;
using NLog;

namespace TemplateSystem.WebApi.Controllers
{
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [AllowAnonymous]       
        [HttpGet]        
        [Route("GetUser")]
        public string GetUser(string username, string password)
        {
            if (CheckUser(username, password))
            {
                var resp = JwtManager.GenerateToken(username);

                logger.Trace("Sample trace message:"+ resp);
                logger.Debug("Sample debug message:"+ resp);
                logger.Info("Sample informational message:"+ resp);
                logger.Warn("Sample warning message:"+ resp);
                logger.Error("Sample error message:"+ resp);
                logger.Fatal("Sample fatal error message:" + resp);
                //
                return resp;
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [Route("CheckUser")]
        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }
    }
}
