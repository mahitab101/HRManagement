using HRManagement.Application.Features.Departments.Commands.CreateDepartment;
using HRManagement.Application.Features.Departments.Queries.GetAllDepartments;
using HRManagement.Application.Features.Departments.Queries.GetDepartmentById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<DepartmentListVm>> GetAll()
        {
            var response = await _mediator.Send(new GetAllDepartmentsQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDetailsVm>> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery() { Id = id });
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateDepartmentCommandResponse>> Create([FromBody] CreateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);

            return CreatedAtAction(nameof(GetById),new {id = result.Data.Id},result);

        }
    }
}
