using AirportDBFirst;
using System.Linq;

namespace AirportSystem
{
    class SectionService
    {
        private airportsystemContext _data { get; }
        private FlightSection _section{ get; }
        public SectionService(airportsystemContext data, FlightSection section)
        {
            _data = data;
            _section = section;
        }
        private void ValidateSeats()
        {
            if (_section.Rows > 100 || _section.Cols > 10) { throw new SectionException("Seats limit reached"); }
            if (_section.Rows <= 0 || _section.Cols <= 0) { throw new SectionException("Seats cannot be 0 or negative"); }
        }
        private bool FlightHasSeatClass()
        {
            return _data.FlightSections.Any(section => section.SeatClass == _section.SeatClass && section.FlightId == _section.FlightId);
        }
        public void Add()
        {
            if (!FlightService.CheckExistance(_data, _section.FlightId)) { throw new FlightException("Flight not found!"); }
            if (FlightHasSeatClass()) { throw new SectionException($"Flight {_section.FlightId} already contains {_section.SeatClass} class!"); }
            ValidateSeats();
            _data.FlightSections.Add(_section);
            _data.SaveChanges();
        }
        public void BookSeat(int row, char col)
        {
            var foundSeat = _data.Seats.FirstOrDefault(s => s.Row == row && s.Col == col.ToString() && s.Section.SeatClass == _section.SeatClass && s.Section.FlightId == _section.FlightId);

            if (foundSeat == null) { throw new SectionException("Seat not found!"); }
            if (foundSeat.Booked == true) { throw new SectionException("Seat has already been booked!"); }

            foundSeat.Booked = true;
            _data.SaveChanges();
        }
    }
}
