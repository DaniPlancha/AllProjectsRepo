using System;
using System.Collections.Generic;

#nullable disable

namespace AirportDBFirst
{
    public partial class Seat
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int Row { get; set; }
        public string Col { get; set; }
        public bool? Booked { get; set; }

        public virtual FlightSection Section { get; set; }
    }
}
