using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserTrainingAndDevelopmentSectionConfig :IEntityTypeConfiguration<UserTrainingAndDevelopmentSection>
    {
        public void Configure(EntityTypeBuilder<UserTrainingAndDevelopmentSection> builder)
        {
            builder.HasOne(utds => utds.User)
               .WithMany(u => u.UserTrainingAndDevelopmentSections)
               .HasForeignKey(utds => utds.UserID);
        }
    }
}
