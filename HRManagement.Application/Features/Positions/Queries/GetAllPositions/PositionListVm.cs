using System;

namespace HRManagement.Application.Features.Positions.Queries.GetAllPositions
{
    public class PositionListVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal BaseSalary { get; set; }
        public Guid DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
