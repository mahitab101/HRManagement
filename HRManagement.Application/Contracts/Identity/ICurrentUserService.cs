using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Contracts.Identity
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        string? Email { get; }
        Guid? EmployeeId { get; }
        IList<string>? Roles { get; }
    }
}
