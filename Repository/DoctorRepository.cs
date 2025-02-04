using AppointmentManagmentApi.RepositoryInterface;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace AppointmentManagmentApi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
 


       
        private readonly AppDbContext db;

        public DoctorRepository(AppDbContext _db)
        {
            db = _db ?? throw new ArgumentNullException(nameof(_db)); 
        }        

        public async Task<List<Doctor>> AllDoctorListQuery(int Id)
        {  
            return await db.Doctors.Where(d => d.Id == Id).ToListAsync();
        }

    }

}
