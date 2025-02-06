using Newtonsoft.Json;
using FluentAssertions;

namespace HolidayBooking.Tests
{
    public class HolidayBookingTests
    {
        [Fact]
        public void DeserializeFlightDataJSONTest()
        {
            FlightData? flightData = JsonConvert.DeserializeObject<FlightData>("{}");

            flightData.Should().NotBeNull();
        }

        [Fact]
        public void DeserializeHotelDataJSONTest()
        {
            HotelData? hotelData = JsonConvert.DeserializeObject<HotelData>("{}");

            hotelData.Should().NotBeNull();
        }

        private class FlightData
        {
        }

        private class HotelData
        {
        }
    }
}