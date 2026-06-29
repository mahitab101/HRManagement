using FluentValidation;

namespace HRManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        public CreateLeaveRequestCommandValidator()
        {
            RuleFor(l => l.EmployeeId)
                .NotEmpty().WithMessage("Employee is required");

            RuleFor(l => l.LeaveTypeId)
                .NotEmpty().WithMessage("Leave type is required");

            RuleFor(l => l.StartDate)
                .NotEmpty().WithMessage("Start date is required");

            RuleFor(l => l.EndDate)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThanOrEqualTo(l => l.StartDate)
                .WithMessage("End date must be on or after the start date");

            RuleFor(l => l.Notes)
                .MaximumLength(500);
        }
    }
}
