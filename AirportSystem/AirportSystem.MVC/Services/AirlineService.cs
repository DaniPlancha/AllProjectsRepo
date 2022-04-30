using AirportDBFirst;
using AirportSystem.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Services
{
    public class AirlineService
    {
        private readonly airportsystemContext _data;
        public AirlineService()
        {
            _data = new airportsystemContext();
        }
        public List<Airline> GetAll()
        {
            return _data.Airlines.ToList();
        }
        public AirlineModel Get(int id)
        {
            var airline = _data.Airlines.Include(a => a.Flights).FirstOrDefault(a => a.Id == id);
            if (airline == null) return null;
            return new AirlineModel(airline.Id, airline.Name, airline.Flights.Select(f => new AirlineFlightModel(f.Id, f.Origin, f.Destination, f.Date.ToString())));
        }
    }
}
