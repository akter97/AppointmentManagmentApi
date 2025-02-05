using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppointmentManagmentApi.Models
{
    public class User 
    {
        [Key]
        public int? Id { get; set; }


        [Required(ErrorMessage = "Username Contact is required.")]
        public string Username { get; set; } = null;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; } = null;
    }
}
