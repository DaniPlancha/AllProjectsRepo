using System;
using System.ComponentModel.DataAnnotations;

namespace Airports_Project_Final.Models
{
    public class FlightSearchModel
    {
        [Required] public string Origin { get; set; }
        [Required] public string Destination { get; set; }
        [Required] [DataType(DataType.Date)] public DateTime Date { get; set; }
    }
}
