using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery:IRequest<BaseResponse<DepartmentDetailsVm>>
    {
        public Guid Id { get; set; }
    }
}
