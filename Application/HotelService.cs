using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class HotelService : IHotelService
    {
        private readonly List<Hotel> _hotels;

        public HotelService(List<Hotel> hotels)
        {
            _hotels = hotels;
        }

        public List<Hotel> GetHotels(string to, DateTime arrivalDate, int nights)
        {
            return _hotels
                .Where(h => h.LocalAirports.Contains(to) && h.ArrivalDate == arrivalDate && h.Nights == nights)
                .ToList();
        }
    }
}
