using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserLearningAndDevelopmentPlanConfig :IEntityTypeConfiguration<UserLearning>
    {
        public void Configure(EntityTypeBuilder<UserLearning> builder)
        {
            builder.HasOne(uldp => uldp.UserGoal)
               .WithMany(u => u.UserLearnings)
               .HasForeignKey(uldp => uldp.UserGoalID);
        }
    }
}
