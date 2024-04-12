using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightManager.Data;
using FlightManager.Models;

namespace FlightManager.Controllers
{
    /// <summary>
    /// Controller for managing flights
    /// </summary>
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new istance of the FlightsController class
        /// </summary>
        /// <param name="context">The context of the database.</param>
        public FlightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Flights
        /// <summary>
        /// Retrieves all flights from the database and passes them to the view
        /// </summary>
        /// <returns>The view containing the list of flights</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flight.ToListAsync());
        }

        // GET: Flights/Details/5
        /// <summary>
        /// Shows the details of a specific flight
        /// </summary>
        /// <param name="id">The ID of the flight for which to display details</param>
        /// <returns>
        /// If the ID is null, returns "Not Found" error.
        /// If the ID of the flight is not found in the database, it returns "Not Found" error.
        /// Otherwise, it returns a view which displays the details of the flight.
        /// </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        /// <summary>
        /// Displays form creating a new flight
        /// </summary>
        /// <returns>The view for creating a new flight</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Adds a new flight based on the submitted form data to the database
        /// </summary>
        /// <param name="flight">The new object of type Flight, containing the data</param>
        /// <returns>
        /// If the flight is successfully added, redirects to the Index to display the list of flights.
        /// Otherwise, it shows again the Create view with validation error messages.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightID,FlightFrom,FlightTo,TakeOffTime,LandingTime,PlaneType,PlaneNumber,PilotName,PlaneCapacity,PlaneBusinessClassCapacity")] Flight flight)
        {
            if (flight.TakeOffTime >= flight.LandingTime) 
            {
                ModelState.AddModelError(nameof(flight.TakeOffTime),"Take Off time can't be after or the same as landing time.");
                ModelState.AddModelError(nameof(flight.LandingTime), "Landing time can't be before or the same as take Off time.");
            }
            
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        /// <summary>
        /// Displays a form to edit the data of a specific flight.
        /// </summary>
        /// <param name="id">The ID of the flight which is to be edited</param>
        /// <returns>
        /// If the ID is not found, returns an error "Not Found".
        /// If the ID is null, returns an error "Not Found".
        /// Otherwise, it returns an Edit view.
        /// </returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Updates the details of a specific flight
        /// </summary>
        /// <param name="id">The ID of the flight to edit</param>
        /// <param name="flight">The flight object containing the updated data</param>
        /// <returns>
        /// If the ID in the form data does not match the ID, returns a "Not Found" error.
        /// If the form data is invalid, it redisplays Edit with validation error messages.
        /// If the form data is valid and the flight is successfully updated, redirects to the Index
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,FlightFrom,FlightTo,TakeOffTime,LandingTime,PlaneType,PlaneNumber,PilotName,PlaneCapacity,PlaneBusinessClassCapacity")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightID))
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
            return View(flight);
        }

        // GET: Flights/Delete/5
        /// <summary>
        /// Displays the form for deleting a flight
        /// </summary>
        /// <param name="id">The ID of the flight</param>
        /// <returns>
        /// If the ID is null, returns an error "Not Found".
        /// If the ID is not found, returns an error "Not Found".
        /// Otherwise, it returns a Delete view.
        /// "</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        /// <summary>
        /// Deleting a specific flight from the database.
        /// </summary>
        /// <param name="id">The ID of the flight to delete</param>
        /// <returns>The Index view after deleting a flight</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            if (flight != null)
            {
                _context.Flight.Remove(flight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if a flight with a certain ID exists in the database
        /// </summary>
        /// <param name="id">The ID of the flight</param>
        /// <returns>True if the flight with the specified ID exists, false otherwise</returns>
        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.FlightID == id);
        }
    }
}
