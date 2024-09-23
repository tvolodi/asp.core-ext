using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_ext.DTO
{
    internal class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap(typeof(server_ext.DAL.BaseEntities.BaseEntity), typeof(server_ext.DTO.DefaultEntityDto<>));
            CreateMap(typeof(server_ext.DTO.DefaultEntityDto<>), typeof(server_ext.DAL.BaseEntities.BaseEntity));
        }
    }
}
