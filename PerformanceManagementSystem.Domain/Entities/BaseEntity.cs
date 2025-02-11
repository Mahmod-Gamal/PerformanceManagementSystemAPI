namespace PerformanceManagementSystem.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T ID { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }



}
