using AppointmentManagmentApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AppointmentManagmentApi._2AppointmentRepositoryI
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(int id);
    }

}
