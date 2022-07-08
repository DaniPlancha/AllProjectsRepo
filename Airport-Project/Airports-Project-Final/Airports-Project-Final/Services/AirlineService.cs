using Airports_Project_Final.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airports_Project_Final.Services
{
    public class AirlineService
    {
        private readonly AirportDbContext _context;
        public AirlineService(AirportDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Airline> GetAll()
        {
            return _context.Airline;
        }
        public Airline Get(int id)
        {
            return _context.Airline.FirstOrDefault(a => a.ID == id);
        }
        /// <summary>
        /// Takes an Airline object as parameter and adds it into the database.
        /// </summary>
        public void Add(Airline airline)
        {
            _context.Airline.Add(airline);
            _context.SaveChanges();
        }

        public void Delete(Airline airport)
        {
            _context.Airline.Remove(airport);
            _context.SaveChanges();
        }

        public void ReplaceInfoWith(Airline airline)
        {
            var current = _context.Airline.FirstOrDefault(a => a.ID == airline.ID);
            current.Name = airline.Name;
            _context.Update(current);
            _context.SaveChanges();
        }
        public bool CheckNameNotExists(int id, string airlineName)
        {
            return !_context.Airline.Any(a => a.Name == airlineName && a.ID != id);
        }
    }
}
