namespace HRManagement.Application.Features.Account.Commands.CreateEmployeeAccount
{
    public class CreateEmployeeAccountCommandResponse
    {
        public string Email { get; set; } = string.Empty;
        public Guid? EmployeeId { get; set; }
    }
}