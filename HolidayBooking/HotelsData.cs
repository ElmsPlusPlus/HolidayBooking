using Newtonsoft.Json;

namespace HolidayBooking.Tests
{
    public class HotelsData
    {
        [JsonProperty("Hotel_Data")]
        public List<HotelData> Hotels { get; set; }

        public List<HotelData> SearchHotels(string airport, string arrivalDate, int nights)
        {
            List<HotelData> matchingHotels = new List<HotelData>();

            foreach (var hotel in Hotels)
            {
                if(hotel.LocalAirports.Contains(airport) && hotel.ArrivalDate == arrivalDate && hotel.Nights == nights)
                {
                   matchingHotels.Add(hotel);
                }
            }

            matchingHotels.Sort((hot1,hot2)=>hot1.PricePerNight.CompareTo(hot2.PricePerNight));

            // TODO: Create expection or special return type for no matching hotels
            return matchingHotels;
        }
    }
}