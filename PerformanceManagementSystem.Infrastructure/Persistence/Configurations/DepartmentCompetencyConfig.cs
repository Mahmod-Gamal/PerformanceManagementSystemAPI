using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace  PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class DepartmentCompetencyConfig : IEntityTypeConfiguration<DepartmentCompetency>
    {
        public void Configure(EntityTypeBuilder<DepartmentCompetency> builder)
        {
            //builder.HasKey(dc => new { dc.DepartmentID, dc.CompetenciesID });

            builder.HasOne(dc => dc.Department)
                .WithMany(d => d.DepartmentCompetencies)
                .HasForeignKey(dc => dc.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.Competency)
                .WithMany(c => c.DepartmentCompetencies)
                .HasForeignKey(dc => dc.CompetencyID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
