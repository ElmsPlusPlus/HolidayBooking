using Newtonsoft.Json;

namespace HolidayBooking.Tests
{
    public class FlightsData
    {
        [JsonProperty("Flight_Data")]
        public List<FlightData> Flights { get; set; }

        public FlightData SearchFlights(string from, string to, string departureDate)
        {
            throw new NotImplementedException();
        }
    }
}