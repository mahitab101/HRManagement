using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Persistence.Configurations
{
    public class PublicHolidayConfiguration : IEntityTypeConfiguration<PublicHoliday>
    {
        public void Configure(EntityTypeBuilder<PublicHoliday> builder)
        {
            builder.Property(h => h.Name).HasMaxLength(200).IsRequired();
            builder.HasIndex(h => h.Date).IsUnique();
        }
    }
}