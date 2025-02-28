using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserObjectiveConfig : IEntityTypeConfiguration<UserObjective>
    {
        public void Configure(EntityTypeBuilder<UserObjective> builder)
        {
            builder.HasOne(uo => uo.UserGoal)
               .WithMany(u => u.UserObjectives)
               .HasForeignKey(uo => uo.UserGoalID);
        }
    }
}
