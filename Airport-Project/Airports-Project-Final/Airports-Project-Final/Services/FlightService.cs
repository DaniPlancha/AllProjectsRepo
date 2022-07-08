using Airports_Project_Final.Data;
using Airports_Project_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airports_Project_Final.Services
{
    public class FlightService
    {
        public readonly AirportDbContext _context;
        public FlightService(AirportDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ListFlightModel> GetAll()
        {
            return _context.Flight.Select(f => new ListFlightModel(
                f.ID,
                _context.Airline.FirstOrDefault(a => a.ID == f.AirlineId).Name,
                _context.Airport.FirstOrDefault(a => a.ID == f.airport_from_id).Name,
                _context.Airport.FirstOrDefault(a => a.ID == f.airport_to_id).Name,
                f.take_off_date, f.landing_date
                )
            );
        }
        public void Create(CreateFlightModel model)
        {
            var flight = new Flight
            {
                AirlineId = _context.Airline.FirstOrDefault(a => a.Name == model.AirlineName).ID,
                airport_from_id = _context.Airport.FirstOrDefault(a => a.PORT_ID == model.AirportFromPORT_ID).ID,
                airport_to_id = _context.Airport.FirstOrDefault(a => a.PORT_ID == model.AirportToPORT_ID).ID,
                take_off_date = model.TakeOffDate,
                landing_date = model.LandingDate
            };
            _context.Flight.Add(flight);
            _context.SaveChanges();
        }

        public IEnumerable<ListFlightModel> GetFilterResults(FlightSearchModel model)
        {
            var origin = _context.Airport.FirstOrDefault(a => a.PORT_ID == model.Origin);
            var destination = _context.Airport.FirstOrDefault(a => a.PORT_ID == model.Destination);

            if (origin == null || destination == null) { return Enumerable.Empty<ListFlightModel>(); }

            return _context.Flight.Where(f => f.airport_from_id == origin.ID && f.airport_to_id == destination.ID && f.take_off_date.Date == model.Date)
                .Select(f => new ListFlightModel(
                    f.ID,
                    _context.Airline.FirstOrDefault(a => a.ID == f.AirlineId).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_from_id).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_to_id).Name,
                    f.take_off_date, f.landing_date
                ));
        }

        public IEnumerable<ListFlightModel> GetSearchResults(string inputValue, string selectValue)
        {
            if (selectValue == "Origin")
            {
                var originAirport = _context.Airport.FirstOrDefault(a => a.PORT_ID == inputValue);

                if (originAirport == null) { return Enumerable.Empty<ListFlightModel>(); }

                return _context.Flight.Where(f => f.airport_from_id == originAirport.ID)
                .Select(f => new ListFlightModel(
                    f.ID,
                    _context.Airline.FirstOrDefault(a => a.ID == f.AirlineId).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_from_id).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_to_id).Name,
                    f.take_off_date, f.landing_date
                ));
            }
            else if (selectValue == "Destination")
            {
                var destinationAirport = _context.Airport.FirstOrDefault(a => a.PORT_ID == inputValue);

                if (destinationAirport == null) { return Enumerable.Empty<ListFlightModel>(); }

                return _context.Flight.Where(f => f.airport_to_id == destinationAirport.ID)
                .Select(f => new ListFlightModel(
                    f.ID,
                    _context.Airline.FirstOrDefault(a => a.ID == f.AirlineId).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_from_id).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_to_id).Name,
                    f.take_off_date, f.landing_date
                ));
            }
            else if (selectValue == "Airline")
            {
                var airline = _context.Airline.FirstOrDefault(a => a.Name == inputValue);

                if (airline == null) { return Enumerable.Empty<ListFlightModel>(); }

                return _context.Flight.Where(f => f.AirlineId == airline.ID)
                .Select(f => new ListFlightModel(
                    f.ID,
                    _context.Airline.FirstOrDefault(a => a.ID == f.AirlineId).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_from_id).Name,
                    _context.Airport.FirstOrDefault(a => a.ID == f.airport_to_id).Name,
                    f.take_off_date, f.landing_date
                ));
            }
            return Enumerable.Empty<ListFlightModel>();
        }

        public void Delete(int id)
        {
            _context.Remove(_context.Flight.FirstOrDefault(f => f.ID == id));
            _context.SaveChanges();
        }
        public CreateFlightModel GenerateCreateFlightModel()
        {
            var allAirlines = new List<string>();
            allAirlines.Add(null);
            allAirlines.AddRange(_context.Airline.Select(a => a.Name));

            var allAirports = new List<string>();
            allAirports.Add(null);
            allAirports.AddRange(_context.Airport.Select(a => a.PORT_ID));

            return new CreateFlightModel { AllAirlines = allAirlines, AllAirports = allAirports};
        }
    }
}
