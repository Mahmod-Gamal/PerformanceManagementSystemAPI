using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerformanceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserGoalConfig : IEntityTypeConfiguration<UserGoal>
    {
        public void Configure(EntityTypeBuilder<UserGoal> builder)
        {
            builder.HasOne(ug => ug.User)
               .WithMany(u => u.UserGoals)
               .HasForeignKey(ug => ug.UserID);
        }
    }
}
