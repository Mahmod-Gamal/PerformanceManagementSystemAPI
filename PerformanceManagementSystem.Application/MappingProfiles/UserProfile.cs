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
                .Map(dest => dest.Duration, src => src.Duration == null ? null : new ForeignDto { ID = src.DurationID, Name = src.Duration.Name })
                .Map(dest => dest.Creator, src => src.Creator == null ? null : new ForeignDto { ID = src.CreatedBy ?? 0, Name = src.Creator.Name })
                .Map(dest => dest.Modifier, src => src.Modifier == null ? null : new ForeignDto { ID = src.ModifiedBy ?? 0, Name = src.Modifier.Name });
        }
    }
}
