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
            //flightData.DepartureDate.Should().BeOfType<string>();
            Assert.IsType<DateTime>(flightData.DepartureDate);
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
            //hotelData.ArrivalDate.Should().BeOfType<DateTime>();
            Assert.IsType<DateTime>(hotelData.ArrivalDate);
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

        [Theory]
        [InlineData ("MAN","AGP","2023-07-01")]
        public void FlightsDataSearch(string from, string to, DateTime departureDate)
        {
            string flightsDataString = System.IO.File.ReadAllText("Flights_Data.json");

            FlightsData flightsData = JsonConvert.DeserializeObject<FlightsData>(flightsDataString);

            List<FlightData> bestFlights = flightsData.SearchFlights(from, to, departureDate);

            bestFlights.First().From.Should().Be(from);
            bestFlights.First().To.Should().Be(to);
            bestFlights.First().DepartureDate.Should().Be(departureDate);
        }

        [Theory]
        [InlineData("AGP", "2023-07-01", 7)]
        public void HotelDataSearch(string airport, DateTime arrivalDate, int nights)
        {
            string hotelsDataString = System.IO.File.ReadAllText("Hotel_Data.json");

            HotelsData hotelsData = JsonConvert.DeserializeObject<HotelsData>(hotelsDataString);

            List<HotelData> bestHotels = hotelsData.SearchHotels(airport, arrivalDate, nights);

            bestHotels.First().LocalAirports.Contains(airport).Should().BeTrue();
            bestHotels.First().ArrivalDate.Should().Be(arrivalDate);
        }

        [Theory]
        [InlineData("MAN","AGP","2023-07-01", 7,2,9)]
        [InlineData("London", "PMI", "2023-06-15", 10, 6, 5)]
        [InlineData("", "LPA", "2022-11-10", 14, 7, 6)]
        public void SpecifiedDepatureHolidaySearch(string from, string to, DateTime date, int nights, int flightID, int hotelID)
        {
            CityAirportsDataManager cityAirportsDataManager = new CityAirportsDataManager();

            HolidaySearcher holidaySearch = new HolidaySearcher("Flights_Data.json", "Hotel_Data.json", cityAirportsDataManager);

            HolidaySearchResults holidaySearchResults = holidaySearch.Search(from, to, date, nights);

            holidaySearchResults.Flights.First().ID.Should().Be(flightID);
            holidaySearchResults.Hotels.First().ID.Should().Be(hotelID);
        }
    }
}