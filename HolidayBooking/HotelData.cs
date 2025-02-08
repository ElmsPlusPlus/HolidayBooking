using Newtonsoft.Json;

namespace HolidayBooking
{
    public class HotelData
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("arrival_date")]
        public string ArrivalDate { get; set; }
        [JsonProperty("price_per_night")]
        public int PricePerNight { get; set; }
        [JsonProperty("local_airports")]
        public string[] LocalAirports { get; set; }
        [JsonProperty("nights")]
        public int Nights { get; set; }
    }
}