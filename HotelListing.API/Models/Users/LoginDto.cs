using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Password is limited from {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
