using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(150);
            builder.Property(b => b.Location).HasMaxLength(255);

            builder.HasIndex(b => b.Name).IsUnique();

            builder.HasOne<Employee>()
                   .WithMany()
                   .HasForeignKey(b => b.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
