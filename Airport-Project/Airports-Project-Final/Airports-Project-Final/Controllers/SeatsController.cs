using Airports_Project_Final.Data;
using Airports_Project_Final.Models;
using Airports_Project_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airports_Project_Final.Controllers
{
    public class SeatsController : Controller
    {
        public readonly SeatService _service;
        public SeatsController(SeatService service)
        {
            _service = service;
        }
        public IActionResult Add(CreateFlightModel model)
        {
            _service.Add(model.RowsEconomy, model.ColsEconomy, "Economy");
            _service.Add(model.RowsBusiness, model.ColsBusiness, "Business");
            _service.Add(model.RowsFirst, model.ColsFirst, "First");
            return RedirectToAction("Index", "Flights");
        }
        public IActionResult Display(int flightid)
        {
            return View(_service.GetAllSeats(flightid));
        }
        public IActionResult Book(int id)
        {
            return View("Display", _service.GetAllSeats(_service.Book(id)));
        }
        public IActionResult Delete(int id)
        {
            return View("Display", _service.GetAllSeats(_service.Delete(id)));
        }
    }
}
