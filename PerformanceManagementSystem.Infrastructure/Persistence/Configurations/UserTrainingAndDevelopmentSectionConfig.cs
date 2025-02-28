using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserTrainingAndDevelopmentSectionConfig :IEntityTypeConfiguration<UserTraining>
    {
        public void Configure(EntityTypeBuilder<UserTraining> builder)
        {
            builder.HasOne(utds => utds.UserGoal)
               .WithMany(u => u.UserTrainings)
               .HasForeignKey(utds => utds.UserGoalID);
        }
    }
}
