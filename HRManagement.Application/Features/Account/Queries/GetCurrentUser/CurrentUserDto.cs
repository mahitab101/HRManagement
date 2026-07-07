namespace HRManagement.Application.Features.Account.Queries.GetCurrentUser
{
    public class CurrentUserDto
    {
        public string Email { get; set; } = string.Empty;
        public Guid? EmployeeId { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}