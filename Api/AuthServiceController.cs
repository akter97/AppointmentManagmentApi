using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagmentApi.Api
{
   
        [Route("api/[controller]")]
        [ApiController]
    public class AuthServiceController : Controller
    {
        private readonly AppDbContext db;

            public AuthServiceController(AppDbContext _db)
            {
                db = _db;
            }

            [HttpGet]
            [Route("GetUser")]
            public async Task<IEnumerable<User>> GetUsers()
            {
                return await db.Users.ToListAsync();
            }

            [HttpPost]
            [Route("AddNewUser")]
            public async Task<User> AddUsers(User obj )
            {
                db.Users.Add(obj );
                await db.SaveChangesAsync();
                return obj ;
            }

            [HttpPatch]
            [Route("UpdateUser")]
            public async Task<User> UpdateUsers(User obj)
            {
                db.Entry(obj ).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return obj ;
            }

            [HttpDelete]
            [Route("DeleteUser/{id}")]
            public bool DeleteUsers(int id)
            {
                bool a = false;
                var student = db.Users.Find(id);
                if (student != null)
                {
                    a = true;
                    db.Entry(student).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                else
                {
                    a = false;
                }
                return a;

            }


        // 

        [HttpGet]
        [Route("GetAppointmentsAll")]
        public async Task<IEnumerable<Appointment>> GetAppointmentsAll()
        {
            return await db.Appointments.ToListAsync();
        }

        [HttpPost]
        [Route("AddNewAppointment")]
        public async Task<Appointment> NewAappointment(Appointment obj)
        {
            db.Appointments.Add(obj );
            await db.SaveChangesAsync();
            return obj;
        }

        [HttpPatch]
        [Route("UpdateAppointment")]
        public async Task<Appointment> UpdateAppointment(Appointment obj)
        {
            db.Entry(obj ).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return obj;
        }

        [HttpDelete]
        [Route("DeleteAppointmentById/{id}")]
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
 