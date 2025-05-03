using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class DurationConfig : IEntityTypeConfiguration<Duration>
    {
        public void Configure(EntityTypeBuilder<Duration> builder)
        {


            builder.HasOne(u => u.DurationType)
               .WithMany(ut => ut.Durations)
               .HasForeignKey(u => u.DurationTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Define conversion for DateOnly <-> DateTime
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue), // Convert DateOnly to DateTime
                d => DateOnly.FromDateTime(d));      // Convert DateTime to DateOnly

            // Configure Start date
            builder.Property(d => d.Start)
                .HasConversion(dateOnlyConverter)  // Apply conversion
                .HasColumnType("DATE");            // Store as DATE in SQL Server

            // Configure End date
            builder.Property(d => d.End)
                .HasConversion(dateOnlyConverter)
                .HasColumnType("DATE");

            builder.Property(u => u.IsPrimary).HasDefaultValue(false);
        }
    }
}
