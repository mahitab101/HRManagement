using Microsoft.AspNetCore.Identity;
using HRManagement.Domain.Entities;
using System;

namespace HRManagement.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}