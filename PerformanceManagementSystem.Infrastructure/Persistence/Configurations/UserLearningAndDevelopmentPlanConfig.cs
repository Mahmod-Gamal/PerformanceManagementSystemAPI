using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserLearningAndDevelopmentPlanConfig :IEntityTypeConfiguration<UserLearningAndDevelopmentPlan>
    {
        public void Configure(EntityTypeBuilder<UserLearningAndDevelopmentPlan> builder)
        {
            builder.HasOne(uldp => uldp.User)
               .WithMany(u => u.UserLearningAndDevelopmentPlans)
               .HasForeignKey(uldp => uldp.UserID);
        }
    }
}
