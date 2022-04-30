using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Models
{
    public record SectionModel(int Id, int FlightId, int Rows, int Cols, string SeatClass, IEnumerable<SectionSeatModel> Seats);
}
