using HRManagement.Application.Contracts.Identity;
using HRManagement.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace HRManagement.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<IEnumerable<Guid>> GetEmployeeIdsWithAccountsAsync()
        {
            var employeeIds = _userManager.Users
                .Where(u => u.EmployeeId.HasValue)
                .Select(u => u.EmployeeId!.Value)
                .AsEnumerable();

            return Task.FromResult(employeeIds);
        }

        public Task<Dictionary<Guid, Guid>> GetEmployeeIdToUserIdMapAsync()
        {
            var result = _userManager.Users
                .Where(u => u.EmployeeId.HasValue)
                .ToDictionary(u => u.EmployeeId!.Value, u => u.Id);

            return Task.FromResult(result);
        }
    }
}