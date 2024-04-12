using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    /// <summary>
    /// Public class describing the table Reservation from the database
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Public property for the ID of each reservation
        /// </summary>
        public int ReservationID { get; set; }

        /// <summary>
        /// Public property for the first name of the passenger 
        /// </summary>
        [Display(Name="First Name/Име")]
        [Required(ErrorMessage="First name required/Името е задължително")]
        public string FirstName { get; set; }

        /// <summary>
        /// Public property for the second name of the passenger
        /// </summary>
        [Display(Name = "Second name/Презиме")]
        [Required(ErrorMessage = "Second name required/Презимето е задължително")]
        public string SecondName { get; set; }

        /// <summary>
        /// Public property for the last name of the passenger
        /// </summary>
        [Display(Name = "Last Name/Фамилия")]
        [Required(ErrorMessage = "Last name required/Фамилията е задължителна")]
        public string LastName { get; set; }

        /// <summary>
        /// Public property for EGN (unique citizenship number) of the passenger
        /// </summary>
        [Display(Name = "EGN/ЕГН")]
        [Required(ErrorMessage = "EGN required/ЕГН-то е задължително"),RegularExpression(@"^([0-9]{10})",ErrorMessage="EGN is not valid!/ЕГН-то е невалидно!")]
        public string EGN { get; set; }

        /// <summary>
        /// Public property for the nationality of the passenger
        /// </summary>
        [Display(Name = "Nationality/Националност")]
        [Required(ErrorMessage = "Nationality required/Националността е задължителна")]
        public string Nationality { get; set; }

        /// <summary>
        /// Public property for the phone number of the passenger
        /// </summary>
        [Display(Name = "Phone number/Телефон")]
        [Required(ErrorMessage = "Phone number required/Мобилният телефон е задължителен")]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Public property for the email of the passenger
        /// </summary>
        [Display(Name = "Email/Имейл")]
        [Required(ErrorMessage = "Email required/Имейлът е задължителен")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Public property for the ID of the reserved flight
        /// </summary>
        [Display(Name = "Flight number/Номер на полета")]
        [Required(ErrorMessage = "Flight number required/Номерът на полета е задължителен")]        
        public int FlightID { get; set; }

        /// <summary>
        /// Public property for the flight the reservation is for
        /// </summary>
        public Flight Flight { get; set; } = null!;

        /// <summary>
        /// Public property for the type of ticket the passenger has reserved
        /// </summary>
        [Display(Name = "Tiket type/Вид билет")]
        [Required(ErrorMessage = "Tiket type required/Видът на билета е задължителен")]
        public string TicketType { get; set; }

        /// <summary>
        /// Initializes a new istance of the class
        /// </summary>
        public Reservation()
        {

        }

    }
}
