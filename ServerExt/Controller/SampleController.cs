using AutoMapper;
using server_ext.DAL;
using server_ext.DAL.BaseEntities;
using server_ext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_ext.Controller
{
    public class SampleController : BaseApiController<SampleEntity, DefaultEntityDto<SampleEntity>>
    {
        public SampleController(
            ILogger logger, 
            BaseAppDbContext context, 
            IMapper mapper) 
            : base(context, mapper)
        {

        }
    }
}
