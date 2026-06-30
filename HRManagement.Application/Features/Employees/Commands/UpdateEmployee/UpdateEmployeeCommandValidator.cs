using FluentValidation;

namespace HRManagement.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Employee Id is required");

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100);

            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100);

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("A valid email address is required");

            RuleFor(e => e.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(e => e.NationalId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(e => e.DateOfBirth)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past");

            RuleFor(e => e.DepartmentId)
                .NotEmpty().WithMessage("Department is required");

            RuleFor(e => e.PositionId)
                .NotEmpty().WithMessage("Position is required");

            RuleFor(e => e.BranchId)
                .NotEmpty().WithMessage("Branch is required");
        }
    }
}
