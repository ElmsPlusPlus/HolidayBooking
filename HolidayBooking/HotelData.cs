namespace HolidayBooking
{
    public class HotelData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string arrival_date { get; set; }
        public int pricepernight { get; set; }
        public string[] local_airports { get; set; }
        public int nights { get; set; }
    }
}