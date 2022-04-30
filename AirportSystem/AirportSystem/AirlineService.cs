using AirportDBFirst;
using System.Linq;

namespace AirportSystem
{
    class AirlineService
    {
        private airportsystemContext _data { get; }
        private Airline _airline { get; }
        public AirlineService(airportsystemContext data, Airline airline)
        {
            _data = data;
            _airline = airline;
        }
        private bool ValidateName()
        {
            var name = _airline.Name;
            if (name.Length > 5) { return false; }

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] < 'A' || (name[i] > 'Z' && name[i] < 'a') || name[i] > 'z')
                    return false;
            }
            return true;
        }
        private bool CheckExistance()
        {
            return _data.Airlines.Any(airline => airline.Name == _airline.Name);
        }
        public void Add()
        {
            if (!ValidateName()) { throw new AirlineException("Invalid airline name!"); }
            if (CheckExistance()) { throw new AirlineException("Airline already exists!"); }
            _data.Airlines.Add(_airline);
            _data.SaveChanges();
        }
    }
}
