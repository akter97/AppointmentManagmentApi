using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
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
            public async Task<IEnumerable<User>> GetStudents()
            {
                return await db.Users.ToListAsync();
            }

            [HttpPost]
            [Route("AddNewUser")]
            public async Task<User> AddStudent(User objStudent)
            {
                db.Users.Add(objStudent);
                await db.SaveChangesAsync();
                return objStudent;
            }

            [HttpPatch]
            [Route("UpdateUser")]
            public async Task<User> UpdateStudent(User objStudent)
            {
                db.Entry(objStudent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return objStudent;
            }

            [HttpDelete]
            [Route("DeleteUser/{id}")]
            public bool DeleteStudent(int id)
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

        }

    }