using HRManagement.Application.Features.Branch.Commands.CreateBranch;
using HRManagement.Application.Features.Branch.Queries.GetAllBranches;
using HRManagement.Application.Features.Branch.Queries.GetBranchByDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRManagement.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllBranchesQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetBranchDetailsQuery { Id = id });

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateBranchCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
    }
}