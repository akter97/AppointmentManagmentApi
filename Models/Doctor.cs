using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AppointmentManagmentApi.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Doctor Name is required.")]
        public string Name { get; set; } = null;
    }
}
