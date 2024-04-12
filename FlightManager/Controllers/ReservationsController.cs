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
    /// Controller for managing reservations
    /// </summary>
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new istance of the ReservationsController class
        /// </summary>
        /// <param name="context">The context of the database.</param>
        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        /// <summary>
        /// Retrieves all reservations from the database and passes them to the view
        /// </summary>
        /// <returns>The view containing the list of reservations</returns>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservation.Include(r => r.Flight);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        /// <summary>
        /// Shows the details of a specific reservation
        /// </summary>
        /// <param name="id">The ID of the reservation for which to display details</param>
        /// <returns>
        /// If the ID is null, returns "Not Found" error.
        /// If the ID of the reservation is not found in the database, it returns "Not Found" error.
        /// Otherwise, it returns a view which displays the details of the reservation.
        /// </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Flight)
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        /// <summary>
        /// Displays form creating a new reservation
        /// </summary>
        /// <returns>The view for creating a new reservation</returns>
        public IActionResult Create()
        {
            ViewData["FlightID"] = new SelectList(_context.Flight, "FlightID", "FlightFrom");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Adds a new reservation based on the submitted form data to the database
        /// </summary>
        /// <param name="reservation">The new object of type Reservation, containing the data</param>
        /// <returns>
        /// If the reservation is successfully added, redirects to the Index to display the list of reservations.
        /// Otherwise, it shows again the Create view with validation error messages.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationID,FirstName,SecondName,LastName,EGN,Nationality,PhoneNumber,Email,FlightID,TicketType")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightID"] = new SelectList(_context.Flight, "FlightID", "FlightFrom", reservation.FlightID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        /// <summary>
        /// Displays a form to edit the data of a specific reservation.
        /// </summary>
        /// <param name="id">The ID of the reservation which is to be edited</param>
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

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["FlightID"] = new SelectList(_context.Flight, "FlightID", "FlightFrom", reservation.FlightID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Updates the details of a specific reservation
        /// </summary>
        /// <param name="id">The ID of the reservation to edit</param>
        /// <param name="reservation">The reservation object containing the updated data</param>
        /// <returns>
        /// If the ID in the form data does not match the ID, returns a "Not Found" error.
        /// If the form data is invalid, it redisplays Edit with validation error messages.
        /// If the form data is valid and the reservation is successfully updated, redirects to the Index
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationID,FirstName,SecondName,LastName,EGN,Nationality,PhoneNumber,Email,FlightID,TicketType")] Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationID))
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
            ViewData["FlightID"] = new SelectList(_context.Flight, "FlightID", "FlightFrom", reservation.FlightID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        /// <summary>
        /// Displays the form for deleting a reservation
        /// </summary>
        /// <param name="id">The ID of the reservation</param>
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

            var reservation = await _context.Reservation
                .Include(r => r.Flight)
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        /// <summary>
        /// Deleting a specific reservation from the database.
        /// </summary>
        /// <param name="id">The ID of the reservation to delete</param>
        /// <returns>The Index view after deleting a reservation</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if a reservation with a certain ID exists in the database
        /// </summary>
        /// <param name="id">The ID of the reservation</param>
        /// <returns>True if the reservation with the specified ID exists, false otherwise</returns>
        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ReservationID == id);
        }
    }
}
