using Newtonsoft.Json;

namespace HolidayBooking.Tests
{
    public class HotelsData
    {
        [JsonProperty("Hotel_Data")]
        public List<HotelData> Hotels { get; set; }

        public HotelData SearchHotels(string airport, string arrivalDate, int nights)
        {
            HotelData bestHotel = null;

            foreach (var hotel in Hotels)
            {
                if(hotel.LocalAirports.Contains(airport) && hotel.ArrivalDate == arrivalDate && hotel.Nights == nights)
                {
                    if (bestHotel == null) { bestHotel = hotel; }
                    else if (hotel.PricePerNight < bestHotel.PricePerNight)
                    {
                        bestHotel = hotel;
                    }
                }
            }

            // TODO: Create expection or special return type for no matching hotel
            return bestHotel;
        }
    }
}