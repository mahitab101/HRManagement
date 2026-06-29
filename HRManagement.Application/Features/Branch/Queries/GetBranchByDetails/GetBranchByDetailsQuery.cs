using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Branch.Queries.GetBranchByDetails
{
    public class GetBranchDetailsQuery : IRequest<BaseResponse<BranchDetailsVm>>
    {
        public Guid Id { get; set; }
    }
}
