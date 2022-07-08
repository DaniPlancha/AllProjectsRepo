using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airports_Project_Final.Models
{
    public class CreateFlightModel
    {
        [Required] public int ID { get; set; }
        [Required] public string AirlineName { get; set; }
        [Required] public string AirportFromPORT_ID { get; set; }
        [Required] public string AirportToPORT_ID { get; set; }
        [Required] public DateTime TakeOffDate { get; set; }
        [Required] public DateTime LandingDate { get; set; }
        [Required] public uint RowsEconomy { get; set; }
        [Required] public uint ColsEconomy { get; set; }
        [Required] public uint RowsBusiness { get; set; }
        [Required] public uint ColsBusiness { get; set; }
        [Required] public uint RowsFirst { get; set; }
        [Required] public uint ColsFirst { get; set; }
        public List<string> AllAirlines { get; set; }
        public List<string> AllAirports { get; set; }
    }
}
