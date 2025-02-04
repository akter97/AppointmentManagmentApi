using AppointmentManagmentApi.Models;

namespace AppointmentManagmentApi.ServiceInterface
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task AddDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
    }
}
