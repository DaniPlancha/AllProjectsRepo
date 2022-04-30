using AirportDBFirst;
using AirportSystem.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Services
{
    public class FlightService
    {
        private readonly airportsystemContext _data;
        public FlightService()
        {
            _data = new airportsystemContext();
        }
        public FlightModel Get(int id)
        {
            var flight = _data.Flights.Include(f => f.FlightSections).FirstOrDefault(f => f.Id == id);
            if (flight == null) return null;
            return new FlightModel(flight.Id, flight.AirlineId, flight.Origin, flight.Destination, flight.Date.ToString(), flight.FlightSections.Select(fs => new FlightFSmodel(fs.Id, (int)fs.Rows, (int)fs.Cols, fs.SeatClass)));
        }
    }
}
