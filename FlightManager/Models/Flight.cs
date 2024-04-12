using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    /// <summary>
    /// Public class describing the table Flight from the database
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Public property for the ID of each flight
        /// </summary>
        public int FlightID { get; set; }
       
        /// <summary>
        /// Public property for the departure place of the flight
        /// </summary>
        [Display(Name = "Flight from/Начална локация")]
        [Required(ErrorMessage = "FlightFrom required/Началната локация е задължителна")]
        public string FlightFrom { get; set; }

        /// <summary>
        /// Public property for the arrival place of the flight
        /// </summary>
        [Display(Name = "Flight to/Крайна локация")]
        [Required(ErrorMessage = "FlightTo required/Крайната локация е задължителна")]
        public string FlightTo { get; set; }

        /// <summary>
        /// Public property for the departure time of the flight
        /// </summary>
        [Display(Name = "TakeOffTime/Време на излитане")]
        [Required(ErrorMessage = "TakeOffTime required/Времето на излитане е задължително")]
        public DateTime TakeOffTime { get; set; }

        /// <summary>
        /// Public property for the time of the arrival of the flight
        /// </summary>
        [Display(Name = "LandingTime/Време на кацане")]
        [Required(ErrorMessage = "LandingTime required/Времето на кацане е задължително")]
        public DateTime LandingTime { get; set; }

        /// <summary>
        /// Public property for the type of the plane for the flight
        /// </summary>
        [Display(Name = "PlaneType/Тип на самолета")]
        [Required(ErrorMessage = "PlaneType required/Типът на самолета е задължителен")]
        public string PlaneType { get; set; }

        /// <summary>
        /// Public property for the number of the plane for the flight
        /// </summary>
        [Display(Name = "PlaneNumber/Номер на самолет")]
        [Required(ErrorMessage = "PlaneNumber required/Номерът на самолета е задължителен")]
        [StringLength(6, ErrorMessage = "PlaneNumber must be 6 characters long./Номерът на самолета трябва да е от 6 символа.")]
        public string PlaneNumber { get; set; }

        /// <summary>
        /// Public property for the name of the pilot who will fly the plane
        /// </summary>
        [Display(Name = "PilotName/Пилот")]
        [Required(ErrorMessage = "PilotName required/Името на пилота е задължително")]
        public string PilotName { get; set; }

        /// <summary>
        /// Public property for the number of available seats on the plane
        /// </summary>
        [Display(Name = "PlaneCapacity/Капацитет")]
        [Required(ErrorMessage = "PlaneCapacity required/Капацитетът е задължително")]
        public int PlaneCapacity { get; set; }

        /// <summary>
        /// Public property for the number of available seats on the plane from business class
        /// </summary>
        [Display(Name = "PlaneBusinessClassCapacity/Капацитет на бизнес класа")]
        [Required(ErrorMessage = "PlaneBusinessClassCapacity required/Капацитетът на бизнес класата е задължителен")]
        public int PlaneBusinessClassCapacity { get; set; }

        /// <summary>
        /// Public property with the different reservations for the flight
        /// </summary>
        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        public Flight()
        {   

        }
}   }
