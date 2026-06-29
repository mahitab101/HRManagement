using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Branch.Queries.GetAllBranches
{
    public class GetAllBranchesQuery:IRequest<BaseResponse<List<BranchListVm>>>
    {
    }
}
