using Newtonsoft.Json;

namespace HolidayBooking
{
    public class FlightsData
    {
        [JsonProperty("Flight_Data")]
        public List<FlightData> Flights { get; set; }

        public List<FlightData> SearchFlights(string from, string to, string departureDate)
        {
            List<FlightData> matchingFlights = new List<FlightData>();

            foreach (var flight in Flights)
            { 
                if(flight.From == from && flight.To == to && flight.DepartureDate == departureDate)
                {
                    matchingFlights.Add(flight);
                }
            }

            matchingFlights.Sort((fl1, fl2) => fl1.Price.CompareTo(fl2.Price));

            // TODO: Create exception or special return type no matching flight is available.
            return matchingFlights;
        }

        public List<FlightData> SearchFlightsAnyDeparture(string to, string date)
        {
            throw new NotImplementedException();
        }

        public List<FlightData> SearchFLightsMultipleDepartureOptions(string[] departureOptions, string to, string date)
        {
            throw new NotImplementedException();
        }
    }
}