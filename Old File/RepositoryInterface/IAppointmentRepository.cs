using AppointmentManagmentApi.Models;

namespace AppointmentManagmentApi.RepositoryInterface
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<Appointment> AddAppointmentAsync(Appointment appointment);
        Task<Appointment> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}