using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery:IRequest<List<EmployeeListVm>>
    {
    }
}
