using FluentValidation;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Queries.GetEmployeeTransferHistory
{
    public class GetEmployeeTransferHistoryQueryValidator : AbstractValidator<GetEmployeeTransferHistoryQuery>
    {
        public GetEmployeeTransferHistoryQueryValidator()
        {
            RuleFor(q => q.EmployeeId)
                .NotEmpty().WithMessage("Employee Id is required");
        }
    }
}
