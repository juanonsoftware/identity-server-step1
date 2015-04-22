using System;
using System.Security.Claims;
using System.Web.Http;

namespace MvcClient1.Controllers
{
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            if (caller == null)
            {
                throw new Exception();
            }

            var subjectClaim = caller.FindFirst("sub");
            if (subjectClaim != null)
            {
                return Json(new
                {
                    message = "OK user",
                    client = caller.FindFirst("client_id").Value,
                    subject = subjectClaim.Value
                });
            }
            else
            {
                return Json(new
                {
                    message = "OK computer",
                    client = caller.FindFirst("client_id").Value
                });
            }
        }
    }
}