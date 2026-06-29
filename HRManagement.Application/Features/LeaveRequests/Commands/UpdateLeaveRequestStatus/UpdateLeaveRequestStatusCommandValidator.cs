using FluentValidation;
using HRManagement.Domain.Enums;

namespace HRManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequestStatus
{
    public class UpdateLeaveRequestStatusCommandValidator : AbstractValidator<UpdateLeaveRequestStatusCommand>
    {
        public UpdateLeaveRequestStatusCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("Leave request Id is required");

            RuleFor(l => l.ApproverId)
                .NotEmpty().WithMessage("Approver is required");

            RuleFor(l => l.Status)
                .Must(s => s == LeaveStatus.Approved || s == LeaveStatus.Rejected)
                .WithMessage("Status must be either Approved or Rejected");
        }
    }
}
