using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.RepositoryInterface;
using AppointmentManagmentApi.ServicesInterface;

namespace AppointmentManagmentApi.Services
{
    public class DoctorServices: IDoctorServices
    {
        private readonly IDoctorRepository _repository;
        public DoctorServices(IDoctorRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Doctor>> AllDoctorListQuery(int Id)
        {
            var entity = await _repository.AllDoctorListQuery(Id);
            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }
            return entity; 
        }

    }
}
