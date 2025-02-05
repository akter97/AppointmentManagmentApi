using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagmentApi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }


        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
