﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_ext.DAL.BaseEntities
{
    public class BaseSoftDelitableEntity<TKey> : BaseEntity
    {
        public bool IsDeleted { get; set; }
    }
}
