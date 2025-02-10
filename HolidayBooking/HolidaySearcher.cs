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
            flightsData = JsonConvert.DeserializeObject<FlightsData>(flightsDataFile);

            hotelsData = JsonConvert.DeserializeObject<HotelsData>(hotelsDataFile);
        }

        public HolidaySearchResults Search(string from, string to, string date, int nights)
        {
            throw new NotImplementedException();
        }
    }
}
