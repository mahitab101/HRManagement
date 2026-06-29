using HRManagement.Application.Features.Positions.Commands.CreatePosition;
using HRManagement.Application.Features.Positions.Queries.GetAllPositions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRManagement.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPositionsQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePositionCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetAll), result);
        }
    }
}