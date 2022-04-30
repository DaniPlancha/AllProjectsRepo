using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Models
{
    public record FlightModel(int Id, int AirlineId, string Origin, string Destination, string Date, IEnumerable<FlightFSmodel> FlightSections);
}
