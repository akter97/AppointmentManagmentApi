using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.RepositoryInterface;
using AppointmentManagmentApi.ServicesInterface;

namespace AppointmentManagmentApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            return await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
        {
            return await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            return await _appointmentRepository.DeleteAppointmentAsync(id);
        }
    }

}
