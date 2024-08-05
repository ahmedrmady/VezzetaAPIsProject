using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezzeta.Core.Entities
{
    public class Appointment : BaseEntity
    {

        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }

        public DayOfWeek Day { get; set; }

        public double Price { get; set; }

        public string DiscoundCode { get; set; }

        public Discound Discound { get; set; }

        public double FinalPrice { get; set; }

        //  public Status Status { get; set; }

        public int SpecializeId { get; set; }
        public Specialize Specialize { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatintId { get; set; }
        public Patient Patient { get; set; }


    }
}
