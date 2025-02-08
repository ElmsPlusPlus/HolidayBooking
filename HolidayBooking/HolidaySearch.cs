using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayBooking.Tests;
using Newtonsoft.Json;

namespace HolidayBooking
{
    public class HolidaySearch
    {
        private FlightsData flightsData;
        private HotelsData hotelsData;

        public HolidaySearch(string flightsDataFile, string hotelsDataFile)
        {
            flightsData = JsonConvert.DeserializeObject<FlightsData>(flightsDataFile);

            hotelsData = JsonConvert.DeserializeObject<HotelsData>(hotelsDataFile);
        }
    }
}
