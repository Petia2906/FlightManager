using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email/Имейл")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name/Име")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name/Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "EGN/ЕГН")]
        [Required(ErrorMessage = "EGN required/ЕГН-то е задължително"), RegularExpression(@"^([0-9]{10})", ErrorMessage = "EGN is not valid!/ЕГН-то е невалидно!")]
        public string EGN { get; set; }

        [Display(Name = "Phone number/Телефон")]
        [Required(ErrorMessage = "Phone number required/Мобилният телефон е задължителен")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address/Адрес")]
        [Required(ErrorMessage = "Address required/Адресът е задължителен")]
        public string Address { get; set; }

        [Display(Name = "Username/Потребителско име")]
        [Required(ErrorMessage = "Username required/Потребителско име е задължителен")]
        public string Username { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The email must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "Role/Потребителско име")]
        public string Role { get; set; }
    }
}
