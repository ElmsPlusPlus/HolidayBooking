using Newtonsoft.Json;
using FluentAssertions;
using Xunit.Sdk;
using System.Runtime.Serialization;

namespace HolidayBooking.Tests
{
    public class HolidayBookingTests
    {
        string flightDataTestJSON = @"{
                            'id': 1,
                            }";

        static string hotelDataTestJSON = @"{
                            'id': 1,
                            }";

        [Fact]
        public void DeserializeFlightDataJSONTest()
        {
            FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

            flightData.Should().NotBeNull();
        }

        [Fact]
        public void DeserializeHotelDataJSONTest()
        {
            HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(hotelDataTestJSON);

            hotelData.Should().NotBeNull();
        }

        [Fact]
        public void FlightDataIDIsAnInteger()
        {
            FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

            flightData.id.Should().Be(1);
        }

        [Fact]
        public void HotelDataIDIsAnInteger()
        {
            HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(hotelDataTestJSON);

            hotelData.id.Should().Be(1);
        }

        private class FlightData
        {
            public int id { get; set; }
        }

        private class HotelData
        { 
            public int id { get; set; }
        }
    }
}