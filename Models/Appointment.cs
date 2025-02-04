namespace AppointmentManagmentApi.Models
{
    public class Appointment
    {
        public int? Id { get; set; }
        public string PatientName { get; set; } = null;
        public string PatientContact { get; set; } = null;
        public DateTime AppointmentDateTime { get; set; } = DateTime.UtcNow;
        public int? DoctorId { get; set; }
        //public Doctor Doctor { get; set; }
    }
}
