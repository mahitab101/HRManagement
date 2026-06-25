using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeDetailsQuery:IRequest<BaseResponse<EmployeeDetailsVm>>
    {
        public Guid Id { get; set; }
    }
}
