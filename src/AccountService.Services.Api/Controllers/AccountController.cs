using AccountService.Application.Accounts.Interfaces;
using AccountService.Application.Accounts.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AccountServices.Services.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> RecoverAll(Guid guid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _accountAppService.GetByGuidAsync(guid));
        }

        [HttpGet]
        public async Task<IActionResult> RecoverAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _accountAppService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Insert(
           [FromBody]InsertAccountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountAppService.InsertAsync(request);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(
          [FromBody]UpdateAccountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountAppService.UpdateAsync(request);

            return Ok();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteByGuid(Guid guid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountAppService.DeleteByGuidAsync(guid);

            return Ok();
        }
    }
}