using HRManagement.Application.Responses;
using MediatR;
using System;

namespace HRManagement.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
