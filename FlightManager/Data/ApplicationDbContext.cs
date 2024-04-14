using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlightManager.Models;

namespace FlightManager.Data
{
    /// <summary>
    /// Represents the database context for the application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationDbContext class
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for managing flights entities in the database
        /// </summary>
        public DbSet<FlightManager.Models.Flight> Flight { get; set; } = default!;

        /// <summary>
        /// Gets or sets the DbSet for managing reservation entitites in the database.
        /// </summary>
        public DbSet<FlightManager.Models.Reservation> Reservation { get; set; } = default!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
