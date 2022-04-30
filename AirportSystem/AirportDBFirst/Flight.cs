using System;
using System.Collections.Generic;

#nullable disable

namespace AirportDBFirst
{
    public partial class Flight
    {
        public Flight()
        {
            FlightSections = new HashSet<FlightSection>();
        }

        public int Id { get; set; }
        public int AirlineId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual ICollection<FlightSection> FlightSections { get; set; }
    }
}
