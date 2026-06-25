using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, BaseResponse<EmployeeDetailsVm>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeDetailsQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<BaseResponse<EmployeeDetailsVm>> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var emplyee = await _employeeRepository.GetByIdAsync(request.Id);
            if (emplyee == null) return BaseResponse<EmployeeDetailsVm>.FailureResponse($"Employee with {request.Id} not found");

            var response = emplyee.ToEmployeeDetailsVm();
            return BaseResponse<EmployeeDetailsVm>.SuccessResponse(response, "Employee retrieved successfully");
        }
    }
}
