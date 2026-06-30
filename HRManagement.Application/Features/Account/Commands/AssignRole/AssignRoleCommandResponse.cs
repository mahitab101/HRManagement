namespace HRManagement.Application.Features.Account.Commands.AssignRole
{
    public class AssignRoleCommandResponse
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}