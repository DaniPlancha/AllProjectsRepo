using System.ComponentModel.DataAnnotations;

namespace Airports_Project_Final.Data
{
    public class Seat
    {
        [Key]
        public int ID { get; set; }
        public int FlightId { get; set; }
        public string Class { get; set; }
        public char Row { get; set; }
        public uint Column { get; set; }
        public bool Booked { get; set; }
    }
}
