using Airports_Project_Final.Services;
using Airports_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Airports_Project_Final.Data;

namespace Airports_Project_Final.Controllers
{
    public class AirportsController : Controller
    {
        public readonly AirportService _service;
        public AirportsController(AirportService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AirportFormModel airport)
        {
            _service.Add(new Airport { PORT_ID = airport.PORT_ID, Name = airport.Name, Adress = airport.Adress, City = airport.City, Country = airport.Country });
            return RedirectToAction("Index", "Airports");
        }
        public IActionResult Delete(int id)
        {
            var airport = _service.Get(id);
            if (airport == null) return NotFound();
            _service.Delete(airport);
            return RedirectToAction("Index", "Airports");
        }
        public IActionResult Edit(int id)
        {
            var airport = _service.Get(id);
            if (airport == null) return NotFound();
            return View(airport);
        }
        [HttpPost]
        public IActionResult Edit(Airport airport)
        {
            _service.Edit(airport);
            return RedirectToAction("Index", "Airports");
        }
        [HttpPost]
        public JsonResult CheckPortIDNotExists(string PORT_ID)
        {
            return Json(_service.CheckPortIDNotExists(PORT_ID));
        }
        [HttpPost]
        public JsonResult CheckNameNotExists(int ID, string Name)
        {
            return Json(_service.CheckNameNotExists(ID, Name));
        }
        [HttpPost]
        public JsonResult CheckAddressNotExists(int ID, string Adress)
        {
            return Json(_service.CheckAddressNotExists(ID, Adress));
        }
    }
}
