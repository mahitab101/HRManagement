using FluentValidation;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Commands.TransferEmployee
{
    public class TransferEmployeeCommandValidator : AbstractValidator<TransferEmployeeCommand>
    {
        public TransferEmployeeCommandValidator()
        {
            RuleFor(t => t.EmployeeId)
                .NotEmpty().WithMessage("Employee is required");

            RuleFor(t => t.ToBranchId)
                .NotEmpty().WithMessage("Destination branch is required");

            RuleFor(t => t.TransferDate)
                .NotEmpty().WithMessage("Transfer date is required");

            RuleFor(t => t.Reason)
                .MaximumLength(500);
        }
    }
}
