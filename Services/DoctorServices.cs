using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.ServicesInterface;

namespace AppointmentManagmentApi.Services
{
    public class DoctorServices: IDoctorServices
    {
        private readonly IDoctorServices _repository;
        public DoctorServices(IDoctorServices repository)
        {
            _repository = repository;
        }
        public async Task<List<Doctor>> AllDoctorListQuery(int Id)
        {

            return await _repository.AllDoctorListQuery(Id);
        }

    }
}
