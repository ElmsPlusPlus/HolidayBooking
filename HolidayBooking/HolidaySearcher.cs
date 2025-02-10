using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolidayBooking
{
    public class HolidaySearcher
    {
        private FlightsData flightsData;
        private HotelsData hotelsData;

        public HolidaySearcher(string flightsDataFile, string hotelsDataFile)
        {
            string flightsDataString = System.IO.File.ReadAllText(flightsDataFile);
            string hotelsDataString = System.IO.File.ReadAllText(hotelsDataFile);

            flightsData = JsonConvert.DeserializeObject<FlightsData>(flightsDataString);

            hotelsData = JsonConvert.DeserializeObject<HotelsData>(hotelsDataString);
        }

        public HolidaySearchResults Search(string from, string to, string date, int nights)
        {
            List<FlightData> bestFlights = flightsData.SearchFlights(from, to, date);
            List<HotelData> bestHotels = hotelsData.SearchHotels(to, date, nights);

            return new HolidaySearchResults(bestFlights, bestHotels);
        }
    }
}
