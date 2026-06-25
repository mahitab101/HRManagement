using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Configurations
{
    public class EmployeeTransferHistoryConfiguration : IEntityTypeConfiguration<EmployeeTransferHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeeTransferHistory> builder)
        {
            builder.Property(e => e.Reason).HasMaxLength(500);

            builder.HasIndex(e => e.EmployeeId);

            builder.HasOne(e => e.Employee)
                   .WithMany()
                   .HasForeignKey(e => e.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.FromBranch)
                   .WithMany()
                   .HasForeignKey(e => e.FromBranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ToBranch)
                   .WithMany()
                   .HasForeignKey(e => e.ToBranchId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
