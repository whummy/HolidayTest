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
    public class FlightServiceTests
    {
        [Fact]
        public void GetFlights_ReturnsCorrectFlights()
        {
            var flights = new List<Flight>
        {
            new Flight { Id = 1, From = "MAN", To = "AGP", DepartureDate = new DateTime(2023, 7, 1), Price = 245 }
        };
            var service = new FlightService(flights);

            var result = service.GetFlights("MAN", "AGP", new DateTime(2023, 7, 1));

            result.Should().HaveCount(1);
            result[0].Id.Should().Be(1);

        }
    }
}
