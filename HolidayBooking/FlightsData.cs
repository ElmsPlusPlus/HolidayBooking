using Newtonsoft.Json;

namespace HolidayBooking.Tests
{
    public class FlightsData
    {
        [JsonProperty("Flight_Data")]
        public List<FlightData> Flights { get; set; }

        public FlightData SearchFlights(string from, string to, string departureDate)
        {
            FlightData bestFlight = null;

            foreach (var flight in Flights)
            { 
                if(flight.From == from && flight.To == to && flight.DepartureDate == departureDate)
                {
                    if (bestFlight == null) { bestFlight = flight; }
                    else if(flight.Price < bestFlight.Price)
                    {
                        bestFlight = flight;
                    }
                }
            }

            // TODO: Create exception or special return type no matching flight is available.
            return bestFlight;
        }
    }
}