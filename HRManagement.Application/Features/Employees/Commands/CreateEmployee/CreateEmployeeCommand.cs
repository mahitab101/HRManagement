using HRManagement.Application.Responses;
using HRManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand:IRequest<BaseResponse<CreateEmployeeCommandResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
        public Guid BranchId { get; set; }
    }
}
