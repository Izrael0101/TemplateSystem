using System.Web.Http;
using TemplateSystem.WebApi.Filters;

namespace TemplateSystem.WebApi.Controllers
{
    [RoutePrefix("api/Value")]
    public class ValueController : ApiController
    {
        [JwtAuthentication]
        [HttpPost]
        [Route("GetValueValidateJWT")]
        public string GetValueValidateJWT()
        {
            return "value";
        }
    }
}
