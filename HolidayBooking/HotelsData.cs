using Newtonsoft.Json;

namespace HolidayBooking.Tests
{
    public class HotelsData
    {
        [JsonProperty("Hotel_Data")]
        public List<HotelData> Hotels { get; set; }
    }
}