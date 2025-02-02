using AppointmentManagmentApi.RepositoryInterface;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagmentApi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
 


        private readonly AppDbContext _db;

        public DoctorRepository(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db)); // Prevents null DbContext
        }

        
        public async Task<List<Doctor>> AllDoctorList(int id)
        {
            return await _db.Doctors
                .FromSqlRaw("EXEC Get_Doctor @Id = {0}", id)
                .ToListAsync();
        }
    }

}
