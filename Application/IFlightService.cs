using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IFlightService
    {
        List<Flight> GetFlights(string from, string to, DateTime departureDate);
    }
}
