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
    public class DepartmentProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Department, DepartmentDtoResponse>()
                .Map(dest => dest.Status, src => src.Status == null ? null : new ForeignDto { ID = src.StatusID, Name = src.Status.Name })
                .Map(dest => dest.Manager, src => src.Manager == null ? null : new ForeignDto { ID = src.ManagerId, Name = src.Manager.Name })
                .Map(dest => dest.Creator, src => src.Creator == null ? null : new ForeignDto { ID = src.CreatedBy ?? 0, Name = src.Creator.Name })
                .Map(dest => dest.Modifier, src => src.Modifier == null ? null : new ForeignDto { ID = src.ModifiedBy ?? 0, Name = src.Modifier.Name });
        }
    }
}
