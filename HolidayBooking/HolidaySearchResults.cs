namespace HolidayBooking
{
    public class HolidaySearchResults
    {
        public List<FlightData> Flights { get; internal set; }
        public List<HotelData> Hotels { get; internal set; }
    }
}