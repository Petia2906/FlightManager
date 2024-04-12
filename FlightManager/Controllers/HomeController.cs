using FlightManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightManager.Controllers
{
    /// <summary>
    /// Controller for handling home-related actions
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the HomeController class
        /// </summary>
        /// <param name="logger">The logger instance for logging</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Displays the home page
        /// </summary>
        /// <returns>The view for the home page</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays the privacy page
        /// </summary>
        /// <returns>The view for the privacy place</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Displays the error page
        /// </summary>
        /// <returns>The view for the error page</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
