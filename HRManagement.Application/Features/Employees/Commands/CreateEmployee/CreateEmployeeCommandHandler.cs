using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using HRManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse<CreateEmployeeCommandResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<BaseResponse<CreateEmployeeCommandResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.ToEntity();
            var newEmplyee = await _employeeRepository.AddAsync(employee);

            var response = new CreateEmployeeCommandResponse() { Id = newEmplyee.Id };
            
            return BaseResponse<CreateEmployeeCommandResponse>.SuccessResponse(response, "Employee created successfully");
        }
    }
}
