using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirportDBFirst;
using AirportSystem.MVC.Services;

namespace AirportSystem.MVC.Controllers
{
    public class SectionsController : Controller
    {
        private readonly SectionService _service;

        public SectionsController()
        {
            _service = new SectionService();
        }

        // GET: Sections/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var flightSection = _service.Get(id.Value);
            if (flightSection == null) return NotFound();
            return View(flightSection);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            //ViewData["FlightId"] = new SelectList(_service.Flights, "Id", "Destination");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FlightId,Rows,Cols,SeatClass")] FlightSection flightSection)
        {
            if (ModelState.IsValid)
            {
                _service.Add(flightSection);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_service.Flights, "Id", "Destination", flightSection.FlightId);
            return View(flightSection);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightSection = await _service.FlightSections.FindAsync(id);
            if (flightSection == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_service.Flights, "Id", "Destination", flightSection.FlightId);
            return View(flightSection);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FlightId,Rows,Cols,SeatClass")] FlightSection flightSection)
        {
            if (id != flightSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(flightSection);
                    await _service.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightSectionExists(flightSection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_service.Flights, "Id", "Destination", flightSection.FlightId);
            return View(flightSection);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightSection = await _service.FlightSections
                .Include(f => f.Flight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightSection == null)
            {
                return NotFound();
            }

            return View(flightSection);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flightSection = await _service.FlightSections.FindAsync(id);
            _service.FlightSections.Remove(flightSection);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightSectionExists(int id)
        {
            return _service.FlightSections.Any(e => e.Id == id);
        }*/
    }
}
