using FluentValidation;

namespace HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        public CreateLeaveTypeCommandValidator()
        {
            RuleFor(l => l.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100);

            RuleFor(l => l.MaxDaysPerYear)
                .GreaterThan(0).WithMessage("Max days per year must be greater than 0");
        }
    }
}
