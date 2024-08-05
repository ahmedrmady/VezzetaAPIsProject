using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezzeta.Core.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
       
        public bool IsDeleted { get; set; }
       
        public DateTime CreatedTime { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
