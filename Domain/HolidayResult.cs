using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class HolidayResult
    {
        public Flight? Flight { get; set; }
        public Hotel? Hotel { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
