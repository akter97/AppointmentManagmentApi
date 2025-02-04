using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagmentApi.Api
{
    public class Doctors : Controller
    {

        private readonly AppDbContext db;

        public Doctors(AppDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("GetDoctor")]
        public async Task<IEnumerable<Doctor>> GetDoctor()
        {
            return await db.Doctors.ToListAsync();
        }

        [HttpPost]
        [Route("AddNewDoctors")]
        public async Task<Doctor> AddDoctors(Doctor obj)
        {
            db.Doctors.Add(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        [HttpPatch]
        [Route("Updatedoctors")]
        public async Task<Doctor> UpdateDoctors(Doctor obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return obj;
        }

        [HttpDelete]
        [Route("DeleteDecotors/{id}")]
        public bool DeleteDoctors(int id)
        {
            bool a = false;
            var doctorss = db.Doctors.Find(id);
            if (doctorss != null)
            {
                a = true;
                db.Entry(doctorss).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;

        }

    }
}
