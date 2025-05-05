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
        private readonly IRichDataInitializer _richDataInitializer;
        private readonly AuditingSaveChangesInterceptor _auditingSaveChangesInterceptor;
        public PerformanceManagementDbContext(DbContextOptions<PerformanceManagementDbContext> options
            , IRichDataInitializer richDataInitializer
            , AuditingSaveChangesInterceptor auditingInterceptor
            )
            : base(options)
        {
            _richDataInitializer = richDataInitializer;
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

            modelBuilder.Entity<UserType>().HasData(_richDataInitializer.UserTypesSeed());
            modelBuilder.Entity<DurationType>().HasData(_richDataInitializer.DurationTypesSeed());
            modelBuilder.Entity<Duration>().HasData(_richDataInitializer.DurationsSeed());
            modelBuilder.Entity<Status>().HasData(_richDataInitializer.StatusesSeed());
            modelBuilder.Entity<CompetencyType>().HasData(_richDataInitializer.CompetencyTypesSeed());
            modelBuilder.Entity<User>().HasData(_richDataInitializer.UsersSeed());
            modelBuilder.Entity<Competency>().HasData(_richDataInitializer.CompetenciesSeed());
            modelBuilder.Entity<Department>().HasData(_richDataInitializer.DepartmentsSeed());
            modelBuilder.Entity<UserGoal>().HasData(_richDataInitializer.GoalsSeed());
            modelBuilder.Entity<UserCompetency>().HasData(_richDataInitializer.UserCompetenciesSeed());
            modelBuilder.Entity<UserObjective>().HasData(_richDataInitializer.UserObjectivesSeed());
            modelBuilder.Entity<UserLearning>().HasData(_richDataInitializer.UserLearningSeed());
            modelBuilder.Entity<UserTraining>().HasData(_richDataInitializer.UserTrainingSeed());

            // Automatically apply all IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditingSaveChangesInterceptor);
        }
    }
}