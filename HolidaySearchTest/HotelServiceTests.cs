using Application;
using Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HolidaySearchTest
{
    public class HotelServiceTests
    {
        [Fact]
        public void GetHotels_ReturnsCorrectHotels()
        {
            var hotels = new List<Hotel>
    {
        new Hotel { Id = 1, LocalAirports = new[] { "AGP" }, ArrivalDate = new DateTime(2023, 7, 1), Nights = 7, PricePerNight = 83 }
    };
            var service = new HotelService(hotels);

            var result = service.GetHotels("AGP", new DateTime(2023, 7, 1), 7);

            result.Should().HaveCount(1);
            result[0].Id.Should().Be(1);
        }
    }
}
