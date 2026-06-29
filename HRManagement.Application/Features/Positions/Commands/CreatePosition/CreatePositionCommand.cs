using HRManagement.Application.Responses;
using MediatR;
using System;

namespace HRManagement.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommand : IRequest<BaseResponse<CreatePositionCommandResponse>>
    {
        public string Title { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public decimal BaseSalary { get; set; }
    }
}
