using HRManagement.Application.Features.LeaveBalances.Queries.GetEmployeeLeaveBalances;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LeaveBalancesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveBalancesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetByEmployee(Guid employeeId)
        {
            var result = await _mediator.Send(new GetEmployeeLeaveBalancesQuery
            {
                EmployeeId = employeeId
            });
            return Ok(result);
        }

    }
}