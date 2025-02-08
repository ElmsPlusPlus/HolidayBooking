using Newtonsoft.Json;
using FluentAssertions;
using Xunit.Sdk;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Data;

namespace HolidayBooking.Tests
{
    public partial class HolidayBookingTests
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

        FlightData flightData = JsonConvert.DeserializeObject<FlightData>(flightDataTestJSON);

        HotelData hotelData = JsonConvert.DeserializeObject<HotelData>(hotelDataTestJSON);

        [Fact]
        public void DeserializeFlightDataJSONTest()
        {
            flightData.Should().NotBeNull();
        }

        [Fact]
        public void DeserializeHotelDataJSONTest()
        {
            hotelData.Should().NotBeNull();
        }

        [Fact]
        public void FlightDataIDIsAnInteger()
        {
            Assert.IsType<int>(flightData.ID);
        }

        [Fact]
        public void FlightDataAirlineIsAString()
        {
            flightData.Airline.Should().BeOfType<string>();
        }

        [Fact]
        public void FlightDataFromIsAString()
        {
            flightData.From.Should().BeOfType<string>();
        }

        [Fact]
        public void FlightDataToIsAString()
        {
            flightData.To.Should().BeOfType<string>();
        }

        [Fact]
        public void FlightDataPriceIsAnInteger()
        {
            Assert.IsType<int>(flightData.Price);
        }

        [Fact]
        public void FlightDataDepartureDataIsAString()
        {
            flightData.DepartureDate.Should().BeOfType<string>();
        }

        [Fact]
        public void HotelDataIDIsAnInteger()
        {
            Assert.IsType<int>(hotelData.ID);
        }

        [Fact]
        public void HotelDataNameIsAString()
        {
            hotelData.Name.Should().BeOfType<string>();
        }

        [Fact]
        public void HotelDataArrivalDateIsAString()
        {
            hotelData.ArrivalDate.Should().BeOfType<string>();
        }

        [Fact]
        public void HotelDataPricePerNightIsAnInt()
        {
            Assert.IsType<int>(hotelData.PricePerNight);
        }

        [Fact]
        public void HotelDataLocalAirportsIsAStringArray()
        {
            hotelData.LocalAirports.Should().BeOfType<string[]>();
        }

        [Fact]
        public void HotelDataNightsIsAnInteger()
        {
            Assert.IsType<int>(hotelData.Nights);
        }

        [Fact]
        public void LoadFlightDataFromFile()
        {
            string flightsDataString = System.IO.File.ReadAllText("Flights_Data.json");

            FlightsData flightsData = JsonConvert.DeserializeObject<FlightsData>(flightsDataString);

            flightsData.Flights.Should().NotBeNull();
        }

        [Fact]
        public void LoadHotelDataFromFile()
        {
            string hotelsDataString = System.IO.File.ReadAllText("Hotel_Data.json");

            HotelsData hotelsData = JsonConvert.DeserializeObject<HotelsData>(hotelsDataString);

            hotelsData.Hotels.Should().NotBeNull();
        }
    }
}