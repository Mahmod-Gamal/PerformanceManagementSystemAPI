using PerformanceManagementSystem.Domain.Entities;
using PerformanceManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Infrastructure.Persistence.DataInitializer
{
    public class RichDataInitializer : DataInitializer,IRichDataInitializer
    {
        public new List<User> UsersSeed()
        {

            CreatePasswordHash("12345678", out var hash, out var salt);
            return new List<User>()
            {
                
                new User
                {
                    ID = 1,
                    Name = "SuperAdmin",
                    Email = "i.mahmoud.gamal@gmail.com",
                    Phone = "1234567890",
                    UserName = "superadmin",
                    OTP = null,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.SuperAdmin,
                    StatusID = 1,
                    SettingGoalsDurationID = 1,
                    MidYearDurationID = 2,
                    EndYearDurationID = 3,
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
                    OTP = null,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "admin",
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.Admin,
                    StatusID = 1,
                 SettingGoalsDurationID = 1,
                    MidYearDurationID = 2,
                    EndYearDurationID = 3,
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
                    OTP = null,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "manager",
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.Manager,
                    StatusID = 1,
                   SettingGoalsDurationID = 1,
                    MidYearDurationID = 2,
                    EndYearDurationID = 3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                },

                new User
                {
                    ID = 4,
                    Name = "Employee1",
                    Email = "employee1@example.com",
                    Phone = "1234567890",
                    OTP = null,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "employee",
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.Employee,
                    StatusID = 1,
                    SettingGoalsDurationID = 1,
                    MidYearDurationID = 2,
                    EndYearDurationID = 3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                },new User
                {
                    ID = 5,
                    Name = "Employee2",
                    Email = "employee2@example.com",
                    Phone = "1234567890",
                    OTP = null,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserName = "employee",
                    TokenVersion = Guid.NewGuid(),
                    UserTypeId = (int)UserTypes.Employee,
                    StatusID = 1,
                    SettingGoalsDurationID = 1,
                    MidYearDurationID = 2,
                    EndYearDurationID = 3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                },
            };
        }

        public List<Competency> CompetenciesSeed()
        {
            return new List<Competency>
            {
                new Competency { ID = 1 , Name = "CoreComp1", Definition = "This is CoreComp1", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 1, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 2 , Name = "CoreComp2", Definition = "This is CoreComp2", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 1, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 3 , Name = "CoreComp3", Definition = "This is CoreComp3", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 1, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 4 , Name = "CoreComp4", Definition = "This is CoreComp4", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 1, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 5 , Name = "CoreComp5", Definition = "This is CoreComp5", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 1, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 6 , Name = "FunctionalComp1", Definition = "This is FunctionalComp1", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 2, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 7 , Name = "FunctionalComp2", Definition = "This is FunctionalComp2", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 2, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 8 , Name = "FunctionalComp3", Definition = "This is FunctionalComp3", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 2, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 9 , Name = "FunctionalComp4", Definition = "This is FunctionalComp4", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 2, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Competency { ID = 10, Name = "FunctionalComp5", Definition = "This is FunctionalComp5", BasicLevelDescription = "Basic", ProficientLevelDescription = "Proficient", AdvancedLevelDescription = "Advanced", ExpertLevelDescription = "Expert", CompetenciesTypeID = 2, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
            };

        }

        public List<Department> DepartmentsSeed()
        {
            return new List<Department>
            {
                new Department { ID = 1, Name = "HR", ManagerId = 1, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
                new Department { ID = 1, Name = "IT", ManagerId = 3, StatusID = 1, CreatedAt = DateTime.Now, CreatedBy = 1, ModifiedAt = DateTime.Now, ModifiedBy = 1 },
            };

        }

        public List<UserGoal> GoalsSeed() {
            return new List<UserGoal>
            {
                new UserGoal { ID = 1, UserID = 1, Year = 2024, StageID = 1 },
                new UserGoal { ID = 2, UserID = 1, Year = 2025, StageID = 1 },
                new UserGoal { ID = 3, UserID = 2, Year = 2024, StageID = 1 },
                new UserGoal { ID = 4, UserID = 2, Year = 2025, StageID = 1 },
                new UserGoal { ID = 5, UserID = 3, Year = 2024, StageID = 1 },
                new UserGoal { ID = 6, UserID = 3, Year = 2025, StageID = 1 },
                new UserGoal { ID = 7, UserID = 4, Year = 2024, StageID = 1 },
                new UserGoal { ID = 8, UserID = 4, Year = 2025, StageID = 1 },
                new UserGoal { ID = 9, UserID = 5, Year = 2024, StageID = 1 },
                new UserGoal { ID = 10, UserID = 5, Year = 2025, StageID = 1 },
            };
        }
        public List<UserCompetency> UserCompetenciesSeed()
        {
            var userGoalCompetencies = new List<UserCompetency>();
            int id = 1;

            for (int userGoalId = 1; userGoalId <= 10; userGoalId++)
            {
                for (int competencyId = 1; competencyId <= 10; competencyId++)
                {
                    userGoalCompetencies.Add(new UserCompetency
                    {
                        ID = id++,
                        UserGoalID = userGoalId,
                        CompetencyID = competencyId,
                        CurrentLevel = 2,
                        ExpectedLevel = 3
                    });
                }
            }

            return userGoalCompetencies;
        }
        
        public List<UserObjective> UserObjectivesSeed()
        {
            var userObjectives = new List<UserObjective>();

            for (int userId = 1; userId <= 5; userId++)
            {
                int userGoal2024 = (userId * 2) - 1;
                int userGoal2025 = userId * 2;

                userObjectives.Add(new UserObjective
                {
                    ID = userObjectives.Count + 1,
                    UserGoalID = userGoal2024,
                    Description = $"Objective for User {userId} - 2024",
                    Measure = "Measure 2024",
                    Target = "Target 2024",
                    DateFrom = new DateTime(2024, 1, 1),
                    DateTo = new DateTime(2024, 12, 31)
                });

                userObjectives.Add(new UserObjective
                {
                    ID = userObjectives.Count + 1,
                    UserGoalID = userGoal2025,
                    Description = $"Objective for User {userId} - 2025",
                    Measure = "Measure 2025",
                    Target = "Target 2025",
                    DateFrom = new DateTime(2025, 1, 1),
                    DateTo = new DateTime(2025, 12, 31)
                });
            }

            return userObjectives;
        }

        public List<UserLearning> UserLearningSeed() {
            var userLearnings = new List<UserLearning>();

            for (int userId = 1; userId <= 5; userId++)
            {
                int userGoal2024 = (userId * 2) - 1;
                int userGoal2025 = userId * 2;

                userLearnings.Add(new UserLearning
                {
                    ID = userLearnings.Count + 1,
                    UserGoalID = userGoal2024,
                    ImprovementArea = $"Time Management - User {userId} - 2024",
                    Action = "Attend time management workshop"
                });

                userLearnings.Add(new UserLearning
                {
                    ID = userLearnings.Count + 1,
                    UserGoalID = userGoal2025,
                    ImprovementArea = $"Communication Skills - User {userId} - 2025",
                    Action = "Join advanced communication training"
                });
            }

            return userLearnings;
        }
        public List<UserTraining> UserTrainingSeed() {
            var userTrainings = new List<UserTraining>();

            for (int learningId = 1; learningId <= 10; learningId++)
            {
                var year = (learningId % 2 == 0) ? 2025 : 2024;

                userTrainings.Add(new UserTraining
                {
                    ID = learningId,
                    UserLearningID = learningId,
                    TrainingCourse = $"Course for Learning {learningId}",
                    InstituteOfSource = "Corporate Training Center",
                    DateFrom = new DateTime(year, 3, 1),
                    DateTo = new DateTime(year, 3, 15)
                });
            }

            return userTrainings;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private string GenerateRandomOTP(int length)
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
