using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_ext.DAL.BaseEntities
{
    public class SoftDelitableEntity<TKey> : BaseEntity<TKey> where TKey : struct
    {
        public bool IsDeleted { get; set; }
    }
}
