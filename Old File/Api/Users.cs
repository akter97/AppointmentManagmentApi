using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagmentApi.Api
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class Users : Controller
    {
        private readonly AppDbContext db;

        public Users(AppDbContext _db)
        {
            db = _db;
        }

        //[HttpGet]
        //[Route("GetUser")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }

        //[HttpPost]
        //[Route("AddNewUser")]
        public async Task<User> AddUsers(User obj)
        {
            db.Users.Add(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        //[HttpPatch]
        //[Route("UpdateUser")]
        public async Task<User> UpdateUsers(User obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return obj;
        }

        //[HttpDelete]
        //[Route("DeleteUser/{id}")]
        public bool DeleteUsers(int id)
        {
            bool a = false;
            var userss = db.Users.Find(id);
            if (userss != null)
            {
                a = true;
                db.Entry(userss).State = EntityState.Deleted;
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
