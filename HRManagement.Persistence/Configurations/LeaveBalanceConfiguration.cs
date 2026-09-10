using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Persistence.Configurations
{
    public class LeaveBalanceConfiguration : IEntityTypeConfiguration<LeaveBalance>
    {
        public void Configure(EntityTypeBuilder<LeaveBalance> builder)
        {
           
            builder.HasIndex(lb => new { lb.EmployeeId, lb.LeaveTypeId, lb.Year })
                   .IsUnique();

            builder.Property(lb => lb.TotalDays)
                   .IsRequired();

            builder.Property(lb => lb.UsedDays)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.HasOne(lb => lb.Employee)
                   .WithMany()
                   .HasForeignKey(lb => lb.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lb => lb.LeaveType)
                   .WithMany()
                   .HasForeignKey(lb => lb.LeaveTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}