using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeDetailsQuery:IRequest<EmployeeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
