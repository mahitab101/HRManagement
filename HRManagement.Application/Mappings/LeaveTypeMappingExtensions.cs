using HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HRManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HRManagement.Application.Mappings.LeaveTypes
{
    public static class LeaveTypeMappingExtensions
    {
        public static LeaveType ToEntity(this CreateLeaveTypeCommand command)
        {
            return new LeaveType
            {
                Name = command.Name,
                MaxDaysPerYear = command.MaxDaysPerYear
            };
        }

        public static LeaveTypeListVm ToLeaveTypeListVm(this LeaveType leaveType)
        {
            return new LeaveTypeListVm
            {
                Id = leaveType.Id,
                Name = leaveType.Name,
                MaxDaysPerYear = leaveType.MaxDaysPerYear
            };
        }

        public static List<LeaveTypeListVm> ToLeaveTypeListVms(this IEnumerable<LeaveType> leaveTypes)
        {
            return leaveTypes.Select(l => l.ToLeaveTypeListVm()).ToList();
        }
    }
}