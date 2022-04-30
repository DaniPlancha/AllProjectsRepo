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
    public class FlightsController : Controller
    {
        private readonly FlightService _service;

        public FlightsController()
        {
            _service = new FlightService();
        }

        // GET: Flights/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var flight = _service.Get(id.Value);
            if (flight == null) return NotFound();
            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            //ViewData["AirlineId"] = new SelectList(_service.Airlines, "Id", "Name");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AirlineId,Origin,Destination,Date")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _service.Add(flight);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineId"] = new SelectList(_service.Airlines, "Id", "Name", flight.AirlineId);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _service.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewData["AirlineId"] = new SelectList(_service.Airlines, "Id", "Name", flight.AirlineId);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AirlineId,Origin,Destination,Date")] Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(flight);
                    await _service.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.Id))
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
            ViewData["AirlineId"] = new SelectList(_service.Airlines, "Id", "Name", flight.AirlineId);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _service.Flights
                .Include(f => f.Airline)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _service.Flights.FindAsync(id);
            _service.Flights.Remove(flight);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _service.Flights.Any(e => e.Id == id);
        }*/
    }
}
