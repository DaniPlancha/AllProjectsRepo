using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airports_Project_Final.Data
{
    public class Airline
    {
        [Required] public int ID { get; set; }
        [Required] [MaxLength(5)] [MinLength(3)] [Remote("CheckNameNotExists", "Airlines", HttpMethod = "POST", ErrorMessage = "Airline with that name already exists.", AdditionalFields = "ID")] public string Name { get; set; }
    }
}
