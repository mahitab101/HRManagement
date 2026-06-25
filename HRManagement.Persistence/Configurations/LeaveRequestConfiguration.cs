using HRManagement.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Configurations
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.Property(l => l.Notes).HasMaxLength(500);

            builder.HasIndex(l => l.EmployeeId);

            builder.HasOne(l => l.Employee)
                    .WithMany()
                    .HasForeignKey(l => l.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.LeaveType)
                   .WithMany()
                   .HasForeignKey(l => l.LeaveTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Employee>()
                   .WithMany()
                   .HasForeignKey(l => l.ApproverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
