using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezzeta.Core.Data.Entities
{
    public class Specialize:BaseEntity
    {
        public string Name { get; set; }
        ICollection<Doctor> Doctors { get; set; }
    }
}
