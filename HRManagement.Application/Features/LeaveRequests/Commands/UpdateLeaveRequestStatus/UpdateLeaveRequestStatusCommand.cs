using HRManagement.Application.Responses;
using HRManagement.Domain.Enums;
using MediatR;
using System;

namespace HRManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequestStatus
{
    public class UpdateLeaveRequestStatusCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
        public Guid ApproverId { get; set; }
        public LeaveStatus Status { get; set; } // Approved or Rejected
    }
}
