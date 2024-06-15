using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class FlightService : IFlightService
    {
        private readonly List<Flight> _flights;

        public FlightService(List<Flight> flights)
        {
            _flights = flights;
        }

        public List<Flight> GetFlights(string from, string to, DateTime departureDate)
        {
            return _flights
                .Where(f => (from == "Any" || f.From == from) && f.To == to && f.DepartureDate == departureDate)
                .ToList();
        }
    }
}
