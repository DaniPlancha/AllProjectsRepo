using Airports_Project_Final.Data;
using System.Collections.Generic;
using System.Linq;

namespace Airports_Project_Final.Services
{
    public class AirportService
    {
        private readonly AirportDbContext _context;
        public AirportService(AirportDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Takes ID as parameter and returns an Airport entity with the same ID from the database.
        /// </summary>
        public Airport Get(int id)
        {
            return _context.Airport.FirstOrDefault(a => a.ID == id);
        }

        /// <summary>
        /// Returns all Airport entities from the database.
        /// </summary>
        public IEnumerable<Airport> GetAll()
        {
            return _context.Airport;
        }

        /// <summary>
        /// Takes an Airport object as parameter and adds it into the database.
        /// </summary>
        public void Add(Airport airport)
        {
            _context.Airport.Add(airport);
            _context.SaveChanges();
        }

        /// <summary>
        /// Takes an Airport object as parameter and removes it from the database.
        /// </summary>
        public void Delete(Airport airport)
        {
            _context.Airport.Remove(airport);
            _context.SaveChanges();
        }

        /// <summary>
        /// Takes an Airport object as parameter. Then searches for an entity in the database with the parameter's ID and updates its info with the parameter's info (without PORT_ID).
        /// </summary>
        public void Edit(Airport airport)
        {
            var current = _context.Airport.FirstOrDefault(a => a.ID == airport.ID);
            current.Name = airport.Name;
            current.Adress = airport.Adress;
            current.City = airport.City;
            current.Country = airport.Country;
            _context.Update(current);
            _context.SaveChanges();
        }
        public bool CheckPortIDNotExists(string PORT_ID)
        {
            return !_context.Airport.Any(a => a.PORT_ID == PORT_ID);
        }
        public bool CheckNameNotExists(int ID, string Name)
        {
            return !_context.Airport.Any(a => a.Name == Name && a.ID != ID);
        }
        public bool CheckAddressNotExists(int ID, string Adress)
        {
            return !_context.Airport.Any(a => a.Adress == Adress && a.ID != ID);
        }
    }
}