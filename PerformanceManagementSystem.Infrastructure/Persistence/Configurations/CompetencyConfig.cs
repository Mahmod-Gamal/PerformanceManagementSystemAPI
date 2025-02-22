using PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class CompetencyConfig : IEntityTypeConfiguration<Competency>
    {
        public void Configure(EntityTypeBuilder<Competency> builder)
        {
            builder.HasOne(c => c.CompetencyType)
                .WithMany(ct => ct.Competencies)
                .HasForeignKey(c => c.CompetenciesTypeID);

            builder.HasOne(c => c.Status)
                .WithMany(s => s.Competencies)
                .HasForeignKey(c => c.StatusID);

            builder.Property(c => c.StatusID).HasDefaultValue(1);

            builder.HasOne(c => c.Creator)
            .WithMany(u => u.CreatedCompetencies)
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Modifier)
              .WithMany(u => u.ModifiedCompetencies)
              .HasForeignKey(c => c.ModifiedBy)
              .OnDelete(DeleteBehavior.Restrict);

            //To be Deleted:

            builder.Property(c => c.CreatedBy).HasDefaultValue(1);
        }
    }
}
