using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class HolidaySearchService
    {
        private readonly IFlightService _flightService;
        private readonly IHotelService _hotelService;

        public HolidaySearchService(IFlightService flightService, IHotelService hotelService)
        {
            _flightService = flightService;
            _hotelService = hotelService;
        }

        public List<HolidayResult> SearchHolidays(string from, string to, DateTime departureDate, int duration)
        {
            var flights = _flightService.GetFlights(from, to, departureDate);
            var hotels = _hotelService.GetHotels(to, departureDate, duration);

            var holidayResults = new List<HolidayResult>();

            foreach (var flight in flights)
            {
                foreach (var hotel in hotels)
                {
                    var totalPrice = flight.Price + hotel.PricePerNight * duration;
                    holidayResults.Add(new HolidayResult
                    {
                        Flight = flight,
                        Hotel = hotel,
                        TotalPrice = totalPrice
                    });
                }
            }

            return holidayResults.OrderBy(hr => hr.TotalPrice).ToList();
        }
    }
}
