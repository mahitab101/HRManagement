using HRManagement.Application.Responses;
using HRManagement.Domain.Enums;
using MediatR;
using System;

namespace HRManagement.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EmployeeStatus Status { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
        public Guid BranchId { get; set; }
    }
}
