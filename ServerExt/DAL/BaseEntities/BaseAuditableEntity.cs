using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_ext.DAL.BaseEntities
{
    public class BaseAuditableEntity<T, TUserKey> : SoftDelitableEntity<T> where T : struct
    {
        public DateTime? CreatedAt { get; set; }
        public TUserKey? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TUserKey? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public TUserKey? DeletedBy { get; set; }
    }
}
