using HRManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRManagement.Application.Features.EmployeeTransferHistories.Queries.GetEmployeeTransferHistory
{
    public class GetEmployeeTransferHistoryQuery : IRequest<BaseResponse<List<TransferHistoryListVm>>>
    {
        public Guid EmployeeId { get; set; }
    }
}
