
using System.Collections.Generic;
using System.Threading.Tasks;
using HRManagement.Domain.Identity;

namespace HRManagement.Application.Contracts.Identity
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user, IList<string> roles);
    }
}