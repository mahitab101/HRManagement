using FluentValidation;
using HRManagement.Application.Features.Branch.Queries.GetBranchByDetails;

namespace HRManagement.Application.Features.Branches.Queries.GetBranchDetails
{
    public class GetBranchDetailsQueryValidator : AbstractValidator<GetBranchDetailsQuery>
    {
        public GetBranchDetailsQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty().WithMessage("Branch Id is required");
        }
    }
}