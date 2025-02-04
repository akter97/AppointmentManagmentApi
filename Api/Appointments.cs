using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagmentApi.Api
{
    public class Appointments : Controller
    { 
            private readonly AppDbContext db;

            public Appointments(AppDbContext _db)
            {
                db = _db;
            }

            [HttpGet]
            [Route("GetAppointmentsol")]
            public async Task<IEnumerable<Appointment>> GetDoctor()
            {
                return await db.Appointments.ToListAsync();
            }

            [HttpPost]
            [Route("AddNewAppointments")]
            public async Task<Appointment> AddDoctors(Appointment obj)
            {
                db.Appointments.Add(obj);
                await db.SaveChangesAsync();
                return obj;
            }

            [HttpPatch]
            [Route("UpdateAppointments")]
            public async Task<Doctor> UpdateAppointments(Doctor obj)
            {
                db.Entry(obj).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return obj;
            }

            [HttpDelete]
            [Route("DeleteAppointmentsById/{id}")]
            public bool DeleteAppointmentsById(int id)
            {
                bool a = false;
                var AppointmentsS = db.Appointments.Find(id);
                if (AppointmentsS != null)
                {
                    a = true;
                    db.Entry(AppointmentsS).State = EntityState.Deleted;
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
