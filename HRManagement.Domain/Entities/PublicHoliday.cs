using HRManagement.Domain.Common;
using System;

namespace HRManagement.Domain.Entities
{
    public class PublicHoliday : AuditableEntity
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}