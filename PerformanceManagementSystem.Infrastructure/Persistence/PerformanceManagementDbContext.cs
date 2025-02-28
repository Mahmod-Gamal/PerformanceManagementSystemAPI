using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Infrastructure.Persistence.Configurations;
using PerformanceManagementSystem.Infrastructure.Persistence.DataInitializer;
using PerformanceManagementSystem.Infrastructure.Persistence.Interceptors;
using System.Reflection;

namespace PerformanceManagementSystem.Infrastructure
{
    public class PerformanceManagementDbContext : DbContext
    {
        private readonly IDataInitializer _dataInitializer;
        private readonly AuditingSaveChangesInterceptor _auditingSaveChangesInterceptor;
        public PerformanceManagementDbContext(DbContextOptions<PerformanceManagementDbContext> options
            , IDataInitializer dataInitializer
            , AuditingSaveChangesInterceptor auditingInterceptor
            )
            : base(options)
        {
            _dataInitializer = dataInitializer;
            _auditingSaveChangesInterceptor = auditingInterceptor;
        }

        public DbSet<Competency> Competencies { get; set; }
        public DbSet<CompetencyType> CompetencyTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentCompetency> DepartmentCompetencies { get; set; }
        public DbSet<Duration> Durations { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompetency> UserCompetencies { get; set; }
        public DbSet<UserGoal> UserGoals { get; set; }
        public DbSet<UserObjective> UserObjectives { get; set; }
        public DbSet<UserLearning> UserLearnings { get; set; }
        public DbSet<UserTraining> UserTrainings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserType>().HasData(_dataInitializer.UserTypesSeed());
            modelBuilder.Entity<Duration>().HasData(_dataInitializer.DurationsSeed());
            modelBuilder.Entity<Status>().HasData(_dataInitializer.StatusesSeed());
            modelBuilder.Entity<CompetencyType>().HasData(_dataInitializer.CompetencyTypesSeed());
            modelBuilder.Entity<User>().HasData(_dataInitializer.UsersSeed());

            // Automatically apply all IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditingSaveChangesInterceptor);
        }
    }
}