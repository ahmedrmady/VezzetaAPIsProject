using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezzeta.Core.Entities
{
    public class Patient : Person
    {
        public ICollection<Appointment> Appointments { get; set; }
    }
}
