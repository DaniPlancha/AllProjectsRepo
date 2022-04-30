using AirportDBFirst;
using AirportSystem.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Services
{
    public class AirportService
    {
        private readonly airportsystemContext _data;
        public AirportService()
        {
            _data = new airportsystemContext();
        }
        public List<Airport> GetAll()
        {
            return _data.Airports.ToList();
        }
        public AirportModel Get(int id)
        {
            var airport = _data.Airports.FirstOrDefault(a => a.Id == id);
            if (airport == null) return null;
            return new AirportModel(airport.Id, airport.Name, _data.Flights.Include(f => f.Airline).Where(f => f.Origin == airport.Name).Select(f => new AirportFlightModel(f.Id, f.Airline.Name, f.Origin, f.Destination, f.Date.ToString())));
        }
    }
}
