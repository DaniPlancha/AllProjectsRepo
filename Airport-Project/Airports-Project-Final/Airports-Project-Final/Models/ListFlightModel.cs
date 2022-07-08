using System;
using System.ComponentModel.DataAnnotations;

namespace Airports_Project_Final.Models
{
    public record ListFlightModel(
        [Required]int ID,
        [Required][MaxLength(5)][MinLength(3)] string AirlineName,
        [Required] string AirportFromName, [Required] string AirportToName,
        [Required] DateTime TakeOffDate,
        [Required] DateTime LandingDate
    );
}
