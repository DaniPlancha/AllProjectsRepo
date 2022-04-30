using System;
using System.Collections.Generic;

#nullable disable

namespace AirportDBFirst
{
    public partial class FlightSection
    {
        public FlightSection()
        {
            Seats = new HashSet<Seat>();
        }

        public int Id { get; set; }
        public int FlightId { get; set; }
        public uint Rows { get; set; }
        public uint Cols { get; set; }
        public string SeatClass { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
