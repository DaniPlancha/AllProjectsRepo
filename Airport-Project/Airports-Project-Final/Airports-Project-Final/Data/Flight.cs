using System;
using System.ComponentModel.DataAnnotations;

namespace Airports_Project_Final.Data
{
    public class Flight
    {
        [Key]
        public int ID { get; set; }
        public int AirlineId { get; set; }
        public int airport_from_id { get; set; }
        public int airport_to_id { get; set; }
        public DateTime take_off_date { get; set; }
        public DateTime landing_date { get; set; }
    }
}
