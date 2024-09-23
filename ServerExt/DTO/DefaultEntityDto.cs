using server_ext.DAL.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_ext.DTO
{
    public class DefaultEntityDto<TEntity> : BaseEntity
        where TEntity : class 
    {
    }
}
