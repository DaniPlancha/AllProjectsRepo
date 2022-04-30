using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Models
{
    public record AirportModel(int Id, string Name, IEnumerable<AirportFlightModel> FlightsFromThisAirport);
}
