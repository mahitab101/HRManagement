using HRManagement.Domain.Enums;

namespace HRManagement.Application.Features.Employees.Queries.GetEmployeeById
{
    public class EmployeeDetailsVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public Guid PositionId { get; set; }
        public string PositionName { get; set; }

        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
    }
}