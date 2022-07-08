using Airports_Project_Final.Data;
using Airports_Project_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airports_Project_Final.Controllers
{
    public class AirlinesController : Controller
    {
        public AirlineService _service;
        public AirlinesController(AirlineService service)
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
        public IActionResult Create(Airline airline)
        {
            _service.Add(airline);
            return RedirectToAction("Index", "Airlines");
        }
        public IActionResult Delete(int id)
        {
            var airport = _service.Get(id);
            if (airport == null) return NotFound();
            _service.Delete(airport);
            return RedirectToAction("Index", "Airlines");
        }
        public IActionResult Edit(int id)
        {
            var airline = _service.Get(id);
            if (airline == null) return NotFound();
            return View(airline);
        }
        [HttpPost]
        public IActionResult Edit(Airline airline)
        {
            _service.ReplaceInfoWith(airline);
            return RedirectToAction("Index", "Airlines");
        }
        [HttpPost]
        public JsonResult CheckNameNotExists(int ID, string Name)
        {
            return Json(_service.CheckNameNotExists(ID, Name));
        }
    }
}
