using BlissRecruitment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlissRecruitment.Services.Api.Controllers
{
    public class ShareController : ApiController
    {
        private readonly IQuestionAppService _questionAppService;

        public ShareController(IQuestionAppService questionAppService)
        {
            _questionAppService = questionAppService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> Shared(string destination_email, string content_url)
        {
            return CustomResponse(await _questionAppService.ShareUrl(destination_email, content_url));
        }
    }
}
