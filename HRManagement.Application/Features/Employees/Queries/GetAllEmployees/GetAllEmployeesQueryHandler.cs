using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeListVm>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeListVm>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var emplyees = await _employeeRepository.GetAllAsync();
            var response = emplyees.ToEmployeeListVms();
            return response;
        }
    }
}
