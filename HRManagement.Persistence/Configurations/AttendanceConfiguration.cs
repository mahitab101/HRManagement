using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasIndex(a => new { a.EmployeeId, a.Date }).IsUnique();

            builder.HasOne(a => a.Employee)
              .WithMany()
              .HasForeignKey(a => a.EmployeeId).
              OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
