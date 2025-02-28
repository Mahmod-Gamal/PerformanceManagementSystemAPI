using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserLearningAndDevelopmentPlanConfig :IEntityTypeConfiguration<UserLearningAndDevelopmentPlan>
    {
        public void Configure(EntityTypeBuilder<UserLearningAndDevelopmentPlan> builder)
        {
            builder.HasOne(uldp => uldp.UserGoal)
               .WithMany(u => u.UserLearningAndDevelopmentPlans)
               .HasForeignKey(uldp => uldp.UserGoalID);
        }
    }
}
