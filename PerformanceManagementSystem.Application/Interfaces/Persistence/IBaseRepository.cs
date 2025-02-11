namespace PerformanceManagementSystem.Infrastructure.Persistence.Repositories
{
        public interface IBaseRepository<TEntity> where TEntity : class
        {
            Task<TEntity> GetByIdAsync(int id);
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task AddAsync(TEntity entity);
            Task AddRangeAsync(IEnumerable<TEntity> entities);
            void Remove(TEntity entity);
            void RemoveRange(IEnumerable<TEntity> entities);
            void Update(TEntity entity);
        }
}
