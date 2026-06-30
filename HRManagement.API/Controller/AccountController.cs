using HRManagement.Application.Features.Account.Commands.AssignRole;
using HRManagement.Application.Features.Account.Commands.CreateEmployeeAccount;
using HRManagement.Application.Features.Account.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("create-employee-account")]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> CreateEmployeeAccount(CreateEmployeeAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(AssignRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //TODO: add remove-role endpoint
    }
}