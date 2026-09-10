namespace HRManagement.Application.Features.LeaveBalances.Queries.GetEmployeeLeaveBalances
{
    public class LeaveBalanceVm
    {
        public Guid Id { get; set; }
        public Guid LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; } = string.Empty;
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays { get; set; }
        public int PendingDays { get; set; }
        public int Year { get; set; }
    }
}