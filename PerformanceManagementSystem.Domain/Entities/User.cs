namespace PerformanceManagementSystem.Domain.Entities
{
    public class User : BaseEntity, IAuditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? OTP { get; set; }
        public Guid TokenVersion { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }
        public int MidYearDurationID { get; set; }
        public Duration MidYearDuration { get; set; }
        public int EndYearDurationID { get; set; }
        public Duration EndYearDuration { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public User Creator { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public User Modifier { get; set; }

        // Navigation property to represent departments managed by the user
        public ICollection<Department> ManagedDepartments { get; set; }
        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> ModifiedUsers { get; set; }
        public ICollection<Department> CreatedDepartments { get; set; }
        public ICollection<Department> ModifiedDepartments { get; set; }

        public ICollection<Competency> CreatedCompetencies{ get; set; }
        public ICollection<Competency> ModifiedCompetencies { get; set; }

        public ICollection<UserGoal> UserGoals { get; set; }


    }
}
