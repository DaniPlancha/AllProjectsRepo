using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Models
{
    public record SectionSeatModel(int Id, int Row, string Col, bool Booked);
}
