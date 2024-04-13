using FlightManager.Controllers;
using FlightManager.Data;
using FlightManager.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace FlightManagerTests
{
    public class FlightsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithListOfFlights()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Seed the database with test data
            using (var context = new ApplicationDbContext(options))
            {
                //context.Flight.AddRange(
                //    new Flight { FlightID = 1, FlightFrom = "Bulgaria", FlightTo = "Spain", TakeOffTime = new DateTime(2024, 4, 13, 10, 30, 0), LandingTime = new DateTime(2024, 4, 13, 13, 0, 0), PlaneType = "RyanAir", PlaneNumber = "33ac", PilotName = "Nathaniel Dawn", PlaneCapacity = 120, PlaneBusinessClassCapacity = 40 },
                //    new Flight { FlightID = 2, FlightFrom = "Spain", FlightTo = "Bulgaria", TakeOffTime = new DateTime(2024, 4, 13, 13, 0, 0), LandingTime = new DateTime(2024, 4, 13, 16, 0, 0), PlaneType = "RyanAir", PlaneNumber = "33ac", PilotName = "Nathaniel Dawn", PlaneCapacity = 120, PlaneBusinessClassCapacity = 40 }
                //);
                //context.SaveChanges();
            }

            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new FlightsController(context);

                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Flight>>(viewResult.Model);
                Assert.Equal(1, model.Count());
            }
               
        }


        [Fact]
        public async Task Details_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new FlightsController(context);

                // Act
                var result = await controller.Details(null);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenFlightNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new FlightsController(context);

                // Act
                var result = await controller.Details(999); // Because flight with ID 999 doesn't exist

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task Details_ReturnsViewResult_WithValidModel_WhenFlightExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Flight.Add(new Flight { FlightID = 1, FlightFrom = "Bulgaria", FlightTo = "Spain", TakeOffTime = new DateTime(2024, 4, 13, 10, 30, 0), LandingTime = new DateTime(2024, 4, 13, 13, 0, 0), PlaneType = "RyanAir", PlaneNumber = "33ac", PilotName = "Nathaniel Dawn", PlaneCapacity = 120, PlaneBusinessClassCapacity = 40 });
                context.SaveChanges();

                var controller = new FlightsController(context);

                // Act
                var result = await controller.Details(1); // ID of the flight is 1

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<Flight>(viewResult.ViewData.Model);
                Assert.Equal(1, model.FlightID);
            }
        }

        [Fact]
        public async Task Create_WithValidModelState_RedirectsToIndex()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new FlightsController(context);

                var flight = new Flight
                {
                    FlightFrom = "Bulgaria",
                    FlightTo = "Spain",
                    TakeOffTime = new DateTime(2024, 4, 13, 10, 30, 0),
                    LandingTime = new DateTime(2024, 4, 13, 13, 0, 0),
                    PlaneType = "RyanAir",
                    PlaneNumber = "33ac",
                    PilotName = "Nathaniel Dawn",
                    PlaneCapacity = 120,
                    PlaneBusinessClassCapacity = 40
                };

                // Act
                var result = await controller.Create(flight);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }
        }

        

        [Fact]
        public async Task Edit_WithNonExistingFlight_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new FlightsController(context);
                var editedFlight = new Flight
                {
                    FlightID = 999
                };

                // Act
                var result = await controller.Edit(999, editedFlight);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task DeleteConfirmed_RemovesFlightAndRedirectsToIndex()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // Seed the database with a flight
                context.Flight.Add(new Flight { FlightID = 4, FlightFrom = "Bulgaria", FlightTo = "Spain", TakeOffTime = new DateTime(2024, 4, 13, 10, 30, 0), LandingTime = new DateTime(2024, 4, 13, 13, 0, 0), PlaneType = "RyanAir", PlaneNumber = "33ac", PilotName = "Nathaniel Dawn", PlaneCapacity = 120, PlaneBusinessClassCapacity = 40 });
                context.SaveChanges();

                var controller = new FlightsController(context);

                // Act
                var result = await controller.DeleteConfirmed(1);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);

                // Verify that the flight was removed from the database
                var flight = await context.Flight.FindAsync(1);
                Assert.Null(flight);
            }
        }

    }
}
    
