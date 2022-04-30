using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Models
{
    public record AirlineModel(int Id, string Name, IEnumerable<AirlineFlightModel> Flights);
}
