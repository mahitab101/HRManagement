using FluentValidation;

namespace HRManagement.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Employee Id is required");
        }
    }
}
