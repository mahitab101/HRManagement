using HRManagement.Application.Responses;
using MediatR;
using System;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Commands.TransferEmployee
{
    public class TransferEmployeeCommand : IRequest<BaseResponse<TransferEmployeeCommandResponse>>
    {
        public Guid EmployeeId { get; set; }
        public Guid ToBranchId { get; set; }
        public DateTime TransferDate { get; set; }
        public string? Reason { get; set; }
    }
}
