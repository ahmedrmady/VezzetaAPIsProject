using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Enums;

namespace Vezzeta.Core.Data.Entities
{
    public class Discound : BaseEntity
    {

        public string discoundCode { get; set; }

        public int requests { get; set; }

        public DiscountType DiscoundType { get; set; }

        public int Value { get; set; }

    }
}
