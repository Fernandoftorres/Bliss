using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlissRecruitment.Services.Api.Controllers
{
    public class HealthController : ApiController
    {
        [AllowAnonymous]
        [HttpGet("health")]
        public async Task<ActionResult> Health()
        {
            return CustomResponse(new
            {
                Status = "OK"
            });
        }

    }
}
