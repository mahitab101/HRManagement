using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Mappings;
using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Branch.Queries.GetAllBranches
{
    public class GetAllBranchesQueryHandler:IRequestHandler<GetAllBranchesQuery,BaseResponse<List<BranchListVm>>>
    {
        private readonly IBranchRepository _branchRepository;

        public GetAllBranchesQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BaseResponse<List<BranchListVm>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllWithEmployeesAsync();
            var response = branches.Select(b => b.ToBranchListVm()).ToList();
            return BaseResponse<List<BranchListVm>>.SuccessResponse(response, "Data Retrived Successfully");
        }
    }
}
