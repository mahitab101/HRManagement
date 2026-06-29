using FluentValidation;

namespace HRManagement.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(150);

            RuleFor(p => p.DepartmentId)
                .NotEmpty().WithMessage("Department is required");

            RuleFor(p => p.BaseSalary)
                .GreaterThan(0).WithMessage("Base salary must be greater than 0");
        }
    }
}
