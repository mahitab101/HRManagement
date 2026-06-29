using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery:IRequest<BaseResponse<List<DepartmentListVm>>>
    {
    }
}
