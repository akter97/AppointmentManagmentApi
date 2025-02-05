using System.ComponentModel.DataAnnotations;

namespace AppointmentManagmentApi.Models
{
    public class Appointment
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Patient Name is required.")]
        public string PatientName { get; set; } = null;

        [Required(ErrorMessage = "Patient Contact is required.")]
        public string PatientContact { get; set; } = null;

        public DateTime AppointmentDateTime { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Doctor ID is required.")]
        public int? DoctorId { get; set; }
        //public Doctor Doctor { get; set; }
    }
}
