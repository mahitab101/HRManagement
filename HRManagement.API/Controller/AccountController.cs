using HRManagement.Application.Features.Account.Commands.AssignRole;
using HRManagement.Application.Features.Account.Commands.CreateEmployeeAccount;
using HRManagement.Application.Features.Account.Commands.Login;
using HRManagement.Application.Features.Account.Commands.RemoveRole;
using HRManagement.Application.Features.Account.Queries.GetCurrentUser;
using HRManagement.Application.Features.Account.Queries.GetUserRoles;
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

            if (result.Success && result.Data != null)
            {
                Response.Cookies.Append("hr_token", result.Data.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
                });
            }
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
        [HttpPost("remove-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRole(RemoveRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("hr_token");
            return Ok();
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _mediator.Send(new GetCurrentUserQuery());
            return Ok(result);
        }



        [HttpGet("user-roles/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserRoles(Guid userId)
        {
            var result = await _mediator.Send(new GetUserRolesQuery { UserId = userId });
            return Ok(result);
        }

    }
}