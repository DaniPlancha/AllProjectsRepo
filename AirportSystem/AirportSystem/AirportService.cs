using AirportDBFirst;
using System.Linq;

namespace AirportSystem
{
    class AirportService
    {
        private airportsystemContext _data { get; }
        private Airport _airport { get; }
        public AirportService(airportsystemContext data, Airport airport)
        {
            _data = data;
            _airport = airport;
        }
        private bool ValidateName()
        {
            var name = _airport.Name;
            if (name.Length != 3) { return false; }

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] < 'A' || name[i] > 'Z')
                    return false;
            }
            return true;
        }
        public static bool CheckExistance(airportsystemContext data, string name)
        {
            return data.Airports.Any(airport => airport.Name == name);
        }
        public void Add()
        {
            if (!ValidateName()) { throw new AirportException("Invalid airport name!"); }
            if (CheckExistance(_data, _airport.Name)) { throw new AirportException("Airport already exists!"); }
            _data.Airports.Add(_airport);
            _data.SaveChanges();
        }
    }
}
