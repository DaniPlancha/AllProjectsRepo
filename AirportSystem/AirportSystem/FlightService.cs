using AirportDBFirst;
using System.Linq;

namespace AirportSystem
{
    class FlightService
    {
        private airportsystemContext _data { get; }
        private Flight _flight { get; }
        public FlightService(airportsystemContext data, Flight flight)
        {
            _data = data;
            _flight = flight;
        }
        public static bool CheckExistance(airportsystemContext data, int id)
        {
            return data.Flights.Any(flight => flight.Id == id);
        }
        public void Add()
        {
            if (CheckExistance(_data, _flight.Id)) { throw new FlightException("Flight already exists!"); }
            if (!AirportService.CheckExistance(_data, _flight.Origin)) { throw new AirportException("Origin airport not found!"); }
            if (!AirportService.CheckExistance(_data, _flight.Destination)) { throw new AirportException("Destination airport not found!"); }
            if (_flight.Origin == _flight.Destination) { throw new AirportException("Origin and Destination airports cannot be the same!"); }
            _data.Flights.Add(_flight);
            _data.SaveChanges();
        }
    }
}
