namespace HolidayBooking
{
    public class HolidaySearchResults
    {
        public HolidaySearchResults(List<FlightData> flightResults, List<HotelData> hotelResults) 
        {
            Flights = flightResults;
            Hotels = hotelResults;
        }

        public List<FlightData> Flights { get; internal set; }
        public List<HotelData> Hotels { get; internal set; }
    }
}