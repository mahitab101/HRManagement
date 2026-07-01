using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Identity
{
    public interface IUserRepository
    {
        Task<IEnumerable<Guid>> GetEmployeeIdsWithAccountsAsync();
    }
}
