using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand:IRequest<BaseResponse<CreateDepartmentCommandResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public Guid? ManagerId { get; set; }
    }
}
