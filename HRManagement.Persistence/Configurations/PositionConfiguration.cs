using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persistence.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
            builder.HasIndex(p => p.Title);

            builder.HasOne(p => p.Department)
                   .WithMany(d => d.Positions)
                   .HasForeignKey(p => p.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
