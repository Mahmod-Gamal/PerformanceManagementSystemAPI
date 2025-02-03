using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace PerformanceManagementSystem.Infrastructure.Persistence.DataInitializer
{
    public class DataInitializer : IDataInitializer
    {
        public List<UserType> UserTypesSeed()
        {
            return new List<UserType>()
            {
                new UserType { ID = 1, Name = "SuperAdmin" },
                new UserType { ID = 2, Name = "Admin" },
                new UserType { ID = 3, Name = "Manager" },
                new UserType { ID = 4, Name = "Employee" }
            };
        }
        public List<Status> StatusesSeed()
        {
            return new List<Status>()
            {
                new Status { ID = 1, Name = "Active" },
                new Status { ID = 2, Name = "Inactive" }
            };
        }
        public List<CompetencyType> CompetencyTypesSeed()
        {
            return new List<CompetencyType>() {
                new CompetencyType { ID = 1, Name = "Technical" },
                new CompetencyType { ID = 2, Name = "Behavioral" }
            };
        }


        public List<User> UsersSeed()
        {
             CreatePasswordHash("12345678", out var hash, out var salt);
            return new List<User>()
            {
                new User
                {
                    ID = 1,
                    Name = "SuperAdmin",
                    Email = "superadmin@example.com",
                    Phone = "1234567890",
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "superadmin",
                    ShouldChangePassword = true,
                    UserTypeId = (int)UserTypes.SuperAdmin,   
                    StatusID = 1,     
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                },

                new User
                {
                    ID = 2,
                    Name = "Admin",
                    Email = "admin@example.com",
                    Phone = "1234567890",
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "admin",
                    ShouldChangePassword = true,
                    UserTypeId = (int)UserTypes.Admin,
                    StatusID = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                },

                new User
                {
                    ID = 3,
                    Name = "Manager",
                    Email = "manager@example.com",
                    Phone = "1234567890",
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "manager",
                    ShouldChangePassword = true,
                    UserTypeId = (int)UserTypes.Manager,
                    StatusID = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                },

                new User
                {
                    ID = 4,
                    Name = "Employee",
                    Email = "employee@example.com",
                    Phone = "1234567890",
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "employee",
                    ShouldChangePassword = true,
                    UserTypeId = (int)UserTypes.Employee,
                    StatusID = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                },
            };
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}

