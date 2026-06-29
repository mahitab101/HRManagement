using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchCommand:IRequest<BaseResponse<CreateBranchCommandResponse>>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
