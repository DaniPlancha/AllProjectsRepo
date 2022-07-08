using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Airports_Project_Final.Data
{
    public class Airport
    {
        [Required] public int ID { get; set; }
        [Required] [MinLength(3)] [MaxLength(3)] [Remote("CheckPortIDNotExists", "Airports", HttpMethod = "POST", ErrorMessage = "Airport with that port ID already exists.")] public string PORT_ID { get; set; }
        [Required] [MaxLength(50)] [Remote("CheckNameNotExists", "Airports", HttpMethod = "POST", ErrorMessage = "Airport with that name already exists.", AdditionalFields = "ID")] public string Name { get; set; }
        [Required] [MaxLength(50)] [Remote("CheckAddressNotExists", "Airports", HttpMethod = "POST", ErrorMessage = "Airport with that address already exists.", AdditionalFields = "ID")] public string Adress { get; set; }
        [Required] [MaxLength(20)] public string City { get; set; }
        [Required] [MaxLength(20)] public string Country { get; set; }
    }
}
