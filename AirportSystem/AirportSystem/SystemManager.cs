using System;
using AirportDBFirst;
using System.Linq;

namespace AirportSystem
{
    class SystemManager
    {
        public airportsystemContext Data { get; set; }
        public SystemManager(airportsystemContext data)
        {
            Data = data;
        }
        private Airline GetAirline(string name)
        {
            return Data.Airlines.FirstOrDefault(airline => airline.Name == name);
        }
        private FlightSection GetSection(int flightID, SeatClass seatClass)
        {
            return Data.FlightSections.FirstOrDefault(fs => fs.FlightId == flightID && fs.SeatClass == seatClass.ToString());
        }
        public void CreateAirport(string name)
        {
            var service = new AirportService(Data, new Airport { Name = name });
            service.Add();
        }
        public void CreateAirline(string name)
        {
            var service = new AirlineService(Data, new Airline { Name = name });
            service.Add();
        }
        public void CreateFlight(int id, string airlineName, string origin, string destination, int year, int month, int day)
        {
            Airline a = GetAirline(airlineName);
            if (a == null) { throw new FlightException("Airline does not exist!"); }
            var service = new FlightService(Data, new Flight { Id = id, AirlineId = a.Id, Origin = origin, Destination = destination, Date = new DateTime(year, month, day) });
            service.Add();
        }
        public void CreateSection(int flightID, int rows, int cols, SeatClass seatClass)
        {
            var service = new SectionService(Data, new FlightSection { FlightId = flightID, Rows = uint.Parse(rows.ToString()), Cols = uint.Parse(cols.ToString()), SeatClass = seatClass.ToString() });
            service.Add();
        }
        public void BookSeat(int flightID, SeatClass seatClass, int row, char col)
        {
            var fs = GetSection(flightID, seatClass);
            if (fs == null) { throw new SectionException("Section with such parameters was not found!"); }
            var service = new SectionService(Data, fs);
            service.BookSeat(row, col);
        }
        public void FindAvailableFlights(string origin, string destination)
        {
            if (!AirportService.CheckExistance(Data, origin)) { throw new AirportException(); }
            if (!AirportService.CheckExistance(Data, destination)) { throw new AirportException(); }
            if (origin == destination) { throw new AirportException(); }

            Console.WriteLine($"\nAll available flights from {origin} to {destination}:");
            foreach (var flight in Data.Flights.Where(f => f.Destination == destination && f.Origin == origin && f.FlightSections.Any(fs => fs.Seats.Any(s => s.Booked == false))))
            {
                Console.WriteLine(flight.Airline.Name + " -> ID: " + flight.Id + ", departure date: " + flight.Date);
            }
        }
        //public void DisplaySystemDetails()
        //{
        //    Console.WriteLine("\nAll available airports:");
        //    foreach (var airport in _airports.Values)
        //    {
        //        Console.WriteLine("  " + airport.Name);
        //    }
        //    Console.WriteLine("\nAll available airlines:");
        //    foreach (var airline in _airlines.Values)
        //    {
        //        airline.DisplayDetails();
        //        Console.WriteLine();
        //    }
        //}
    }
}
