using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezzeta.Core.Entities
{
    public class Doctor : Person
    {

        public Specialize Specialize { get; set; }

        ICollection<Appointment> Appointments { get; set; }


    }
}
