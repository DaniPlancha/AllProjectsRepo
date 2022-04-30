using AirportDBFirst;
using AirportSystem.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Services
{
    public class SectionService
    {
        private readonly airportsystemContext _data;
        public SectionService()
        {
            _data = new airportsystemContext();
        }
        public SectionModel Get(int id)
        {
            var section = _data.FlightSections.Include(fs => fs.Seats).FirstOrDefault(fs => fs.Id == id);
            if (section == null) return null;
            return new SectionModel(section.Id, section.FlightId, (int)section.Rows, (int)section.Cols, section.SeatClass, section.Seats.Select(s => new SectionSeatModel(s.Id, s.Row, s.Col, (bool)s.Booked)));
        }
    }
}
