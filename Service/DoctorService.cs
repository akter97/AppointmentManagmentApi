using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.Repository;
using AppointmentManagmentApi.RepositoryInterface;
using AppointmentManagmentApi.ServiceInterface;
using System.Numerics;

namespace AppointmentManagmentApi.Service
{
    public class DoctorService: IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.AddAsync(doctor);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }
}
