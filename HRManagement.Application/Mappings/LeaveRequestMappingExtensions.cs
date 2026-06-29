using HRManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;
using HRManagement.Application.Features.LeaveRequests.Queries.GetAllLeaveRequests;
using HRManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HRManagement.Application.Mappings.LeaveRequests
{
    public static class LeaveRequestMappingExtensions
    {
        public static LeaveRequest ToEntity(this CreateLeaveRequestCommand command)
        {
            return new LeaveRequest
            {
                EmployeeId = command.EmployeeId,
                LeaveTypeId = command.LeaveTypeId,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                Notes = command.Notes
            };
        }

        public static LeaveRequestListVm ToLeaveRequestListVm(this LeaveRequest leaveRequest)
        {
            return new LeaveRequestListVm
            {
                Id = leaveRequest.Id,
                EmployeeId = leaveRequest.EmployeeId,
                EmployeeName = leaveRequest.Employee != null
                    ? $"{leaveRequest.Employee.FirstName} {leaveRequest.Employee.LastName}"
                    : null,
                LeaveTypeId = leaveRequest.LeaveTypeId,
                LeaveTypeName = leaveRequest.LeaveType?.Name,
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                Status = leaveRequest.Status.ToString(),
                Notes = leaveRequest.Notes
            };
        }

        public static List<LeaveRequestListVm> ToLeaveRequestListVms(this IEnumerable<LeaveRequest> leaveRequests)
        {
            return leaveRequests.Select(l => l.ToLeaveRequestListVm()).ToList();
        }
    }
}