using FluentValidation;

namespace HRManagement.Application.Features.Account.Commands.CreateEmployeeAccount
{
    public class CreateEmployeeAccountCommandValidator : AbstractValidator<CreateEmployeeAccountCommand>
    {
        public CreateEmployeeAccountCommandValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("EmployeeId is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}