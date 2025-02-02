using  PerformanceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace  PerformanceManagementSystem.Infrastructure.Persistence.Configurations
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(d => d.Status)
               .WithMany(s => s.Departments)
               .HasForeignKey(d => d.StatusID);

            builder.HasOne(d => d.Manager)
               .WithMany(u => u.ManagedDepartments)
               .HasForeignKey(d => d.ManagerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Creator)
             .WithMany(u => u.CreatedDepartments)
             .HasForeignKey(d => d.CreatedBy)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Modifier)
              .WithMany(u => u.ModifiedDepartments)
              .HasForeignKey(d => d.ModifiedBy)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}