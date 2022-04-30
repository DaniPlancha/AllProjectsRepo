using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Models
{
    public record AirportFlightModel(int Id, string AirlineName, string Origin, string Destination, string Date);
}
