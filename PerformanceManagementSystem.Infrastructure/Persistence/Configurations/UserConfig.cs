using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.UserType)
               .WithMany(ut => ut.Users)
               .HasForeignKey(u => u.UserTypeId);

            builder.HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentID);

            builder.HasOne(u => u.Status)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.StatusID).HasDefaultValue(1);

            builder.HasOne(u => u.EndYearDuration)
              .WithMany(u => u.Users)
              .HasForeignKey(u => u.EndYearDurationID)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.MidYearDuration)
              .WithMany(u => u.Users)
              .HasForeignKey(u => u.MidYearDurationID)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Creator)
              .WithMany(u => u.CreatedUsers)
              .HasForeignKey(u => u.CreatedBy)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Modifier)
              .WithMany(u => u.ModifiedUsers)
              .HasForeignKey(u => u.ModifiedBy)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
