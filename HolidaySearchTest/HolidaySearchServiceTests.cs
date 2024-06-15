using Application;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchTest
{
    public class HolidaySearchServiceTests
    {
        public static void SearchHolidays_ReturnsBestValueHoliday()
        {
            var flights = new List<Flight>
    {
        new Flight { Id = 2, From = "MAN", To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 245 }
    };
            var hotels = new List<Hotel>
    {
        new Hotel { Id = 9, LocalAirports = new[] { "AGP" }, ArrivalDate = new DateTime(2023, 7, 1), Nights = 7, PricePerNight = 83 }
    };

            var flightServiceMock = new Mock<IFlightService>();
            flightServiceMock.Setup(fs => fs.GetFlights("MAN", "AGP", new DateTime(2023, 7, 1))).Returns(flights);

            var hotelServiceMock = new Mock<IHotelService>();
            hotelServiceMock.Setup(hs => hs.GetHotels("AGP", new DateTime(2023, 7, 1), 7)).Returns(hotels);

            var service = new HolidaySearchService(flightServiceMock.Object, hotelServiceMock.Object);

            var result = service.SearchHolidays("MAN", "AGP", new DateTime(2023, 7, 1), 7);

            result.Should().HaveCount(1);
            result[0].Flight.Id.Should().Be(2);
            result[0].Hotel.Id.Should().Be(9);
            result[0].TotalPrice.Should().Be(828);
        }
    }
}
