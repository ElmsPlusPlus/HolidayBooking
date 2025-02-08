using Newtonsoft.Json;

namespace HolidayBooking
{
    public class FlightData
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("airline")]
        public string Airline { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("departure_date")]
        public string DepartureDate { get; set; }
    }
}