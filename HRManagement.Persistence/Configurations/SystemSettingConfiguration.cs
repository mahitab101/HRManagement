using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRManagement.Persistence.Configurations
{
    public class SystemSettingConfiguration : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            
            builder.HasIndex(s => s.BranchId)
                   .IsUnique()
                   .HasFilter("[BranchId] IS NOT NULL");

            builder.Property(s => s.WeekendDays)
                .HasConversion(
                    v => string.Join(',', v.Select(d => (int)d)),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(x => (DayOfWeek)int.Parse(x))
                          .ToList())
                .Metadata.SetValueComparer(new ValueComparer<List<DayOfWeek>>(
                    (a, b) => a!.SequenceEqual(b!),
                    v => v.Aggregate(0, (hash, d) => HashCode.Combine(hash, d)),
                    v => v.ToList()));

            builder.Property(s => s.WorkingHoursPerDay).HasColumnType("decimal(4,2)");

            builder.HasOne(s => s.Branch)
                   .WithMany()
                   .HasForeignKey(s => s.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}