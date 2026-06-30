using HRManagement.Application.Features.Employees.Commands.CreateEmployee;
using HRManagement.Application.Features.Employees.Commands.DeleteEmployee;
using HRManagement.Application.Features.Employees.Commands.UpdateEmployee;
using HRManagement.Application.Features.Employees.Queries.GetAllEmployees;
using HRManagement.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllEmployeesQuery { PageNumber = pageNumber, PageSize = pageSize };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetEmployeeDetailsQuery { Id = id });

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateEmployeeCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand { Id = id });

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}