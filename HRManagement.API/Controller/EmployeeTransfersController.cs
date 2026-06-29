using HRManagement.Application.Features.EmployeeTransferHistories.Commands.TransferEmployee;
using HRManagement.Application.Features.EmployeeTransferHistories.Queries.GetEmployeeTransferHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HRManagement.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTransfersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeTransfersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Transfer([FromBody] TransferEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult> GetHistory(Guid employeeId)
        {
            var result = await _mediator.Send(new GetEmployeeTransferHistoryQuery { EmployeeId = employeeId });
            return Ok(result);
        }
    }
}