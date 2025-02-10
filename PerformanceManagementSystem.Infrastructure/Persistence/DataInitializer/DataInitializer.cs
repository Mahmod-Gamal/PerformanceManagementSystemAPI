﻿using PerformanceManagementSystem.Domain.Entities;
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
        public List<Duration> DurationsSeed()
        {
            return new List<Duration>() {
                new Duration { ID = 1, Name = "Main 2025",Start = new DateTime(year:2025,month:1,day:1),End = new DateTime(year:2025,month:5,day:31) }
            };
        }


        public List<User> UsersSeed()
        {
            //CreatePasswordHash("12345678", out var hash, out var salt);
            string otp = GenerateRandomOTP(10);
            return new List<User>()
            {
                new User
                {
                    ID = 1,
                    Name = "SuperAdmin",
                    Email = "i.mahmoud.gamal@gmail.com",
                    Phone = "1234567890",
                    UserName = "superadmin",
                    OTP = otp,
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.SuperAdmin,
                    StatusID = 1,
                    DurationID = 1,
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
                    OTP = otp,
                    UserName = "admin",
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.Admin,
                    StatusID = 1,
                    DurationID = 1,
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
                    OTP = otp,
                    UserName = "manager",
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.Manager,
                    StatusID = 1,
                    DurationID = 1,
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
                    OTP = otp,
                    UserName = "employee",
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.Employee,
                    StatusID = 1,
                    DurationID = 1,
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
        public string GenerateRandomOTP(int length)
        {
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string digitChars = "0123456789";
            const string specialChars = "!@#$%^&*";
            const string allChars = upperChars + lowerChars + digitChars + specialChars;
            char[] otp = new char[length];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            otp[0] = GetRandomChar(upperChars, rng);
            otp[1] = GetRandomChar(lowerChars, rng);
            otp[2] = GetRandomChar(digitChars, rng);
            otp[3] = GetRandomChar(specialChars, rng); 
            for (int i = 4; i < length; i++)
            {
                otp[i] = GetRandomChar(allChars, rng);
            }
            return new string(otp.OrderBy(_ => GetRandomInt(rng)).ToArray());
        }

        private char GetRandomChar(string characterSet, RandomNumberGenerator rng)
        {
            byte[] randomByte = new byte[1];
            rng.GetBytes(randomByte);
            return characterSet[randomByte[0] % characterSet.Length];
        }

        private int GetRandomInt(RandomNumberGenerator rng)
        {
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);
            return BitConverter.ToInt32(randomBytes, 0);
        }
    }
}