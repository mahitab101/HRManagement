using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.Branch.Commands.CreateBranch;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;

namespace HRManagement.Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BaseResponse<CreateBranchCommandResponse>>
    {
        private readonly IBranchRepository _branchRepository;

        public CreateBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BaseResponse<CreateBranchCommandResponse>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = request.ToEntity();
            var created = await _branchRepository.AddAsync(branch);

            var response = new CreateBranchCommandResponse { Id = created.Id };

            return BaseResponse<CreateBranchCommandResponse>.SuccessResponse(response, "Branch created successfully");
        }
    }
}