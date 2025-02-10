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

        CityAirportsDataManager cityAirportsDataManager;

        public HolidaySearcher(string flightsDataFile, string hotelsDataFile, CityAirportsDataManager airportsDataManager)
        {
            string flightsDataString = System.IO.File.ReadAllText(flightsDataFile);
            string hotelsDataString = System.IO.File.ReadAllText(hotelsDataFile);

            flightsData = JsonConvert.DeserializeObject<FlightsData>(flightsDataString);

            hotelsData = JsonConvert.DeserializeObject<HotelsData>(hotelsDataString);

            cityAirportsDataManager = airportsDataManager;
        }

        public HolidaySearchResults Search(string from, string to, DateTime date, int nights)
        {
            List<FlightData> bestFlights;

            if (from == "" || from == string.Empty || from == null)
            {
                bestFlights = flightsData.SearchFlightsAnyDeparture(to, date);
            }
            else if(from.All(char.IsUpper) && from.Length == 3) // Airport code is 3 letters all capitals so will always represent a single airport.
            {
                bestFlights = flightsData.SearchFlights(from, to, date);
            }
            else
            {
                bestFlights = flightsData.SearchFLightsMultipleDepartureOptions(cityAirportsDataManager.GetCityAirports(from.ToLower()), to, date);

                /*string[] departureOptions = {"","" };

                if(from.ToLower() == "london")
                {
                    bestFlights = flightsData.SearchFLightsMultipleDepartureOptions(LondonAirports, to, date);
                }
                else
                {
                    bestFlights = flightsData.SearchFLightsMultipleDepartureOptions(departureOptions, to, date);
                } */
            }

            List<HotelData> bestHotels = hotelsData.SearchHotels(to, date, nights);

            return new HolidaySearchResults(bestFlights, bestHotels);
        }
    }
}
