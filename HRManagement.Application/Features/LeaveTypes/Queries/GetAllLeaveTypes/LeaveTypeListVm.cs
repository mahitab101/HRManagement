using System;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public class LeaveTypeListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MaxDaysPerYear { get; set; }
    }
}
