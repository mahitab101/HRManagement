using HRManagement.Application.Features.SystemSettings.Commands.UpsertSystemSetting;
using HRManagement.Application.Features.SystemSettings.Queries.GetSystemSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HRManagement.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SystemSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] Guid? branchId)
        {
            var response = await _mediator.Send(new GetSystemSettingQuery { BranchId = branchId });
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Upsert([FromBody] UpsertSystemSettingCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}