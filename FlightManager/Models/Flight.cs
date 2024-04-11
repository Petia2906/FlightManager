using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class Flight
    {
        
        public int FlightID { get; set; }

        [Display(Name = "Flight from/Начална локация")]
        [Required(ErrorMessage = "FlightFrom required/Началната локация е задължителна")]
        public string FlightFrom { get; set; }

        [Display(Name = "Flight to/Крайна локация")]
        [Required(ErrorMessage = "FlightTo required/Крайната локация е задължителна")]
        public string FlightTo { get; set; }

        [Display(Name = "TakeOffTime/Време на излитане")]
        [Required(ErrorMessage = "TakeOffTime required/Времето на излитане е задължително")]
        public DateTime TakeOffTime { get; set; }

        [Display(Name = "LandingTime/Време на кацане")]
        [Required(ErrorMessage = "LandingTime required/Времето на кацане е задължително")]
        public DateTime LandingTime { get; set; }

        [Display(Name = "PlaneType/Тип на самолета")]
        [Required(ErrorMessage = "PlaneType required/Типът на самолета е задължителен")]
        public string PlaneType { get; set; }

        [Display(Name = "PlaneNumber/Номер на самолет")]
        [Required(ErrorMessage = "PlaneNumber required/Номерът на самолета е задължителен")]
        [StringLength(6, ErrorMessage = "PlaneNumber must be 6 characters long./Номерът на самолета трябва да е от 6 символа.")]
        public string PlaneNumber { get; set; }

        [Display(Name = "PilotName/Пилот")]
        [Required(ErrorMessage = "PilotName required/Името на пилота е задължително")]
        public string PilotName { get; set; }

        [Display(Name = "PlaneCapacity/Капацитет")]
        [Required(ErrorMessage = "PlaneCapacity required/Капацитетът е задължително")]
        public int PlaneCapacity { get; set; }

        [Display(Name = "PlaneBusinessClassCapacity/Капацитет на бизнес класа")]
        [Required(ErrorMessage = "PlaneBusinessClassCapacity required/Капацитетът на бизнес класата е задължителен")]
        public int PlaneBusinessClassCapacity { get; set; }
        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();
        public Flight()
        {   

        }
}   }
