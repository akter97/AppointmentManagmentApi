using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagmentApi.Api
{
   
        //[Route("api/[controller]")]
        //[ApiController]
    public class AuthServiceController : Controller
    {

        private readonly AppDbContext db;

        public AuthServiceController(AppDbContext _db)
        {
            db = _db;
        }
        // 

        //[HttpGet]
        //[Route("GetAppointmentsAll")]
        public async Task<IEnumerable<Appointment>> GetAppointmentsAll()
        {
            return await db.Appointments.ToListAsync();
        }

        //[HttpPost]
        //[Route("AddNewAppointment")]
        public async Task<Appointment> NewAappointment(Appointment obj)
        {
            db.Appointments.Add(obj );
            await db.SaveChangesAsync();
            return obj;
        }

        //[HttpPatch]
        //[Route("UpdateAppointment")]
        public async Task<Appointment> UpdateAppointment(Appointment obj)
        {
            db.Entry(obj ).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return obj;
        }

        //[HttpDelete]
        //[Route("DeleteAppointmentById/{id}")]
        public bool DeleteAppointmentById(int id)
        {
            bool a = false;
            var aId = db.Appointments.Find(id);
            if (aId != null)
            {
                a = true;
                db.Entry(aId).State = EntityState.Deleted;
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
 