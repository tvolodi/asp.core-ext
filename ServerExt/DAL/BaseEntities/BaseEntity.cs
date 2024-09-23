using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_ext.DAL.BaseEntities
{
    /// <summary>
    /// Base entity class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string? Name { get; set; }
    }
}
