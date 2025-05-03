using Mapster;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.MappingProfiles
{
    public class UserProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDtoResponse>()
                .Map(dest => dest.Status, src => src.Status == null ? null : new ForeignDto { ID = src.StatusID, Name = src.Status.Name })
                .Map(dest => dest.Type, src => src.UserType == null ? null : new ForeignDto { ID = src.UserTypeId, Name = src.UserType.Name })
                .Map(dest => dest.Department, src => src.Department == null ? null : new ForeignDto { ID = src.Department.ID, Name = src.Department.Name })
                .Map(dest => dest.SettingGoalsDuration, src => src.SettingGoalsDuration == null ? null : new ForeignDto { ID = src.SettingGoalsDurationID, Name = src.SettingGoalsDuration.Name })
                .Map(dest => dest.MidYearDuration, src => src.MidYearDuration == null ? null : new ForeignDto { ID = src.MidYearDurationID, Name = src.MidYearDuration.Name })
                .Map(dest => dest.EndYearDuration, src => src.EndYearDuration == null ? null : new ForeignDto { ID = src.EndYearDurationID, Name = src.EndYearDuration.Name })
                .Map(dest => dest.Creator, src => src.Creator == null ? null : new ForeignDto { ID = src.CreatedBy, Name = src.Creator.Name })
                .Map(dest => dest.Modifier, src => src.Modifier == null ? null : new ForeignDto { ID = src.ModifiedBy ?? 0, Name = src.Modifier.Name });
        }
    }
}
