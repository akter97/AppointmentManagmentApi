using AppointmentManagmentApi.Models;

namespace AppointmentManagmentApi.RepositoryInterface
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> AllDoctorListQuery(int Id);
    }
}
