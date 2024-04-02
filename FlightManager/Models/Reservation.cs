using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class Reservation
    {
        
        public int ReservationID { get; set; }

        [Display(Name="First Name/Име")]
        [Required(ErrorMessage="First name required/Името е задължително")]
        public string FirstName { get; set; }

        [Display(Name = "Second name/Презиме")]
        [Required(ErrorMessage = "Second name required/Презимето е задължително")]
        public string SecondName { get; set; }

        [Display(Name = "Last Name/Фамилия")]
        [Required(ErrorMessage = "Last name required/Фамилията е задължителна")]
        public string LastName { get; set; }

        [Display(Name = "EGN/ЕГН")]
        [Required(ErrorMessage = "EGN required/ЕГН-то е задължително"),RegularExpression(@"^([0-9]{10})",ErrorMessage="EGN is not valid!/ЕГН-то е невалидно!")]
        public string EGN { get; set; }

        [Display(Name = "Nationality/Националност")]
        [Required(ErrorMessage = "Nationality required/Националността е задължителна")]
        public string Nationality { get; set; }

        [Display(Name = "Phone number/Телефон")]
        [Required(ErrorMessage = "Phone number required/Мобилният телефон е задължителен"),RegularExpression(@"^([\+][0-9]{1,3}[0-9]{4,12})",ErrorMessage="Phone number is not valid!/Телефонният номер е невалиден!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email/Имейл")]
        [Required(ErrorMessage = "Email required/Имейлът е задължителен")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Flight number/Номер на полета")]
        [Required(ErrorMessage = "Flight number required/Номерът на полета е задължителен")]
        
        //[ForeignKey("Flight")]

        public int FlightID { get; set; }

        [Display(Name = "Tiket type/Вид билет")]
        [Required(ErrorMessage = "Tiket type required/Видът на билета е задължителен")]
        public string TicketType { get; set; }

        public Reservation()
        {

        }

    }
}
