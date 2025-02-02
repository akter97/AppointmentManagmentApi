using AppointmentManagmentApi.Models;

namespace AppointmentManagmentApi.ServicesInterface
{
    public interface IDoctorServices
    {
        Task<List<Doctor>> AllDoctorListQuery(int Id);
    }
}
