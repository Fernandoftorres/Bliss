using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlissRecruitment.Application.Interfaces;
using BlissRecruitment.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlissRecruitment.Services.Api.Controllers
{
    public class QuestionController : ApiController
    {
        private readonly IQuestionAppService _questionAppService;

        public QuestionController(IQuestionAppService questionAppService)
        {
            _questionAppService = questionAppService;
        }

        [AllowAnonymous]
        [HttpGet("questions")]
        public async Task<IEnumerable<QuestionViewModel>> Get(string filter, string limit = "10", string offset = "0")
        {
            int _limit, _offset = 0;

            int.TryParse(limit, out _limit);
            int.TryParse(offset, out _offset);

            return await _questionAppService.GetAll(filter, _limit, _offset);
        }

        [AllowAnonymous]
        [HttpGet("questions/{id}")]
        public async Task<QuestionViewModel> Get(long id)
        {
            return await _questionAppService.GetById(id);
        }

        [HttpPost("questions")]
        public async Task<IActionResult> Post([FromBody] RegisterQuestionViewModel registerQuestionViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) :
                CustomResponse(await _questionAppService.Register(registerQuestionViewModel));
        }

        [HttpPut("questions/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateQuestionViewModel questionViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) :
                CustomResponse(await _questionAppService.Update(questionViewModel));
        }
    }
}
