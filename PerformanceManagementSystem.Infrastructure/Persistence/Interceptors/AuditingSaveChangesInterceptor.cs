
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PerformanceManagementSystem.Domain.Entities;

namespace PerformanceManagementSystem.Infrastructure.Persistence.Interceptors
{
    public class AuditingSaveChangesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added && entry.Entity is IAuditable auditableEntity)
                {
                    auditableEntity.CreatedAt = DateTime.UtcNow;
                    auditableEntity.CreatedBy = 1;
                }
                if (entry.State == EntityState.Modified && entry.Entity is IAuditable auditableEntityUpdate)
                {
                    auditableEntityUpdate.ModifiedAt = DateTime.UtcNow;
                    auditableEntityUpdate.ModifiedBy = 1;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }

}
