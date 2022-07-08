using Airports_Project_Final.Models;
using Airports_Project_Final.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Airports_Project_Final.Controllers
{
    public class FlightsController : Controller
    {
        public readonly FlightService _service;
        public FlightsController(FlightService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        public IActionResult Create()
        {
            return View(_service.GenerateCreateFlightModel());
        }
        [HttpPost]
        public IActionResult Create(CreateFlightModel model)
        {
            _service.Create(model);
            return RedirectToAction("Add", "Seats", model);
        }
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Filter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Filter(FlightSearchModel model)
        {
            return View("Index", _service.GetFilterResults(model));
        }
        public IActionResult Search(string inputValue, string selectValue)
        {
            return View("Index", _service.GetSearchResults(inputValue, selectValue));
        }
    }
}
