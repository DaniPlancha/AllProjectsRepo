using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSystem.MVC.Models
{
    public record AirlineFlightModel(int Id, string Origin, string Destination, string Date);
}
