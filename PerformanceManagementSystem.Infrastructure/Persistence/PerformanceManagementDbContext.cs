using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Configurations;
using PerformanceManagementSystem.Infrastructure.Persistence.DataInitializer;

namespace PerformanceManagementSystem.Infrastructure
{
    public class PerformanceManagementDbContext : DbContext
    {
        private readonly IDataInitializer _dataInitializer;
        public PerformanceManagementDbContext(DbContextOptions<PerformanceManagementDbContext> options
            , IDataInitializer dataInitializer)
            : base(options)
        {
            _dataInitializer = dataInitializer;
        }

        public DbSet<Competency> Competencies { get; set; }
        public DbSet<CompetencyType> CompetencyTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentCompetency> DepartmentCompetencies { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompetency> UserCompetencies { get; set; }
        public DbSet<UserObjective> UserObjectives { get; set; }
        public DbSet<UserLearningAndDevelopmentPlan> UserLearningAndDevelopmentPlans { get; set; }
        public DbSet<UserTrainingAndDevelopmentSection> UserTrainingAndDevelopmentSections { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserType>().HasData(_dataInitializer.UserTypesSeed());
            modelBuilder.Entity<Duration>().HasData(_dataInitializer.DurationsSeed());
            modelBuilder.Entity<Status>().HasData(_dataInitializer.StatusesSeed());
            modelBuilder.Entity<CompetencyType>().HasData(_dataInitializer.CompetencyTypesSeed());
            modelBuilder.Entity<User>().HasData(_dataInitializer.UsersSeed());

            modelBuilder.ApplyConfiguration(new UserTypeConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new CompetencyConfig());
            modelBuilder.ApplyConfiguration(new DepartmentCompetencyConfig());
            modelBuilder.ApplyConfiguration(new UserCompetencyConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserLearningAndDevelopmentPlanConfig());
            modelBuilder.ApplyConfiguration(new UserTrainingAndDevelopmentSectionConfig());
            modelBuilder.ApplyConfiguration(new UserObjectiveConfig());
        }
    }
}