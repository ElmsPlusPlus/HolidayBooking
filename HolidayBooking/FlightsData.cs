using Newtonsoft.Json;

namespace HolidayBooking.Tests
{
    public class FlightsData
    {
        [JsonProperty("Flight_Data")]
        public List<FlightData> Flights { get; set; }
    }
}