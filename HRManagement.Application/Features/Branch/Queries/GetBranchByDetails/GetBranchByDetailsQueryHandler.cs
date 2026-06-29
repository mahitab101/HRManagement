using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.Branch.Queries.GetBranchByDetails;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.Branches.Queries.GetBranchDetails
{
    public class GetBranchDetailsQueryHandler : IRequestHandler<GetBranchDetailsQuery, BaseResponse<BranchDetailsVm>>
    {
        private readonly IBranchRepository _branchRepository;

        public GetBranchDetailsQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BaseResponse<BranchDetailsVm>> Handle(GetBranchDetailsQuery request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdWithDetailsAsync(request.Id);

            if (branch == null)
                return BaseResponse<BranchDetailsVm>.FailureResponse($"Branch with Id {request.Id} not found");

            var response = branch.ToBranchDetailsVm();

            return BaseResponse<BranchDetailsVm>.SuccessResponse(response, "Branch retrieved successfully");
        }
    }
}