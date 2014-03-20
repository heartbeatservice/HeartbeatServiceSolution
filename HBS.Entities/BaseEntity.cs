using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBS.Entities
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
