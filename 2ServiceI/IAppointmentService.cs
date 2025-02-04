using AppointmentManagmentApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentManagmentApi._2ServiceI
{

    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);
    }
}