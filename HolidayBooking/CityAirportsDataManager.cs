using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBooking
{
    public class CityAirportsDataManager
    {
        private Dictionary<string, List<string>> cityAirports = new Dictionary<string, List<string>>
        {
            {"london", new List<string> { "LCY", "LHR", "LGW", "LTN","STN", "SEN" } }
        };


        public List<string> GetCityAirports(string cityName)
        {
            return cityAirports[cityName];
        }
    }
}
