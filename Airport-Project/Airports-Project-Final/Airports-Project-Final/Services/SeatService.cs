using Airports_Project_Final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airports_Project_Final.Services
{
    public class SeatService
    {
        public readonly AirportDbContext _context;
        public SeatService(AirportDbContext context)
        {
            _context = context;
        }
        public void Add(uint Rows, uint Cols, string Class)
        {
            var flId = _context.Flight.OrderBy(f => f.ID).Last().ID;
            for (int row = 1; row <= Rows; row++)
            {
                for (int col = 1; col <= Cols; col++)
                {
                    _context.Seat.Add(new Seat { FlightId = flId, Row = (char)(row + 64), Column = (uint)col, Class = Class });
                }
            }
            _context.SaveChanges();
        }
        public IEnumerable<Seat> GetAllSeats(int flightid)
        {
            return _context.Seat.Where(s => s.FlightId == flightid).OrderByDescending(s => s.Class).ThenBy(s => s.Row).ThenBy(s => s.Column);
        }
        public int Book(int id)
        {
            var seat = _context.Seat.FirstOrDefault(s => s.ID == id);
            if (!seat.Booked)
            {
                seat.Booked = true;
                _context.SaveChanges();
            }
            return seat.FlightId;
        }
        public int Delete(int id)
        {
            var seat = _context.Seat.FirstOrDefault(s => s.ID == id);
            _context.Seat.Remove(seat);
            _context.SaveChanges();
            return seat.FlightId;
        }
    }
}
