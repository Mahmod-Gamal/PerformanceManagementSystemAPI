namespace PerformanceManagementSystem.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IDurationRepository DurationRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ICompetencyRepository CompetencyRepository { get; }
        ICompetencyTypeRepository CompetencyTypeRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
