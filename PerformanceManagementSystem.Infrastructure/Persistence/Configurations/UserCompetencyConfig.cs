using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace  PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserCompetencyConfig :IEntityTypeConfiguration<UserCompetency>
    {
        public void Configure(EntityTypeBuilder<UserCompetency> builder)
        {
            builder.HasOne(uc => uc.UserGoal)
                .WithMany(u => u.UserCompetencies)
                .HasForeignKey(uc => uc.UserGoalID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uc => uc.Competency)
                .WithMany(c => c.UserCompetencies)
                .HasForeignKey(uc => uc.CompetencyID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
