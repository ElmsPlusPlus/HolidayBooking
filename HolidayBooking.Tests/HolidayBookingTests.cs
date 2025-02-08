using Newtonsoft.Json;
using FluentAssertions;
using Xunit.Sdk;
using System.Runtime.Serialization;

namespace HolidayBooking.Tests
{
    public class HolidayBookingTests
    {
        static string flightDataTestJSON = @"{
                                    'id': 1,
                                    'airline': ""First Class Air"",
                                    'from': ""MAN"",
                                    'to': ""TFS"",
                                    'price': 470,
                                    'departure_date': ""2023-07-01""
                                    }";

        static string hotelDataTestJSON = @"{
                                            'id': 1,
                                            'name': ""Iberostar Grand Portals Nous"",
                                            'arrival_date': ""2022-11-05"",
                                            'price_per_night': 100,
                                            'local_airports': [ ""TFS"" ],
                                            'nights': 7
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

            //flightData.id.Should().BeOfType<int>();
            Assert.IsType<int>(flightData.id);
        }

        [Fact]
        public void FlightDataAirlineIsAString()
        {
            FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

            flightData.airline.Should().BeOfType<string>();
        }

        [Fact]
        public void FlightDataFromIsAString()
        {
            FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

            flightData.from.Should().BeOfType<string>();
        }

        [Fact]
        public void FlightDataToIsAString()
        {
            FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

            flightData.to.Should().BeOfType<string>();
        }

        [Fact]
        public void FlightDataPriceIsAnInteger()
        {
            FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

            Assert.IsType<int>(flightData.price);
        }

        [Fact]
        public void FlightDataDepartureDataIsAString()
        {
            FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

            flightData.departure_date.Should().BeOfType<string>();
        }

        [Fact]
        public void HotelDataIDIsAnInteger()
        {
            HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(hotelDataTestJSON);

            //hotelData.id.Should().Be(typeof(int));
            Assert.IsType<int>(hotelData.id);
        }

        private class FlightData
        {
            public int id { get; set; }
            public string airline { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public int price { get; set; }
            public string departure_date { get; set; }
        }

        private class HotelData
        { 
            public int id { get; set; }
        }
    }
}