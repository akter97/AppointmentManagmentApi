using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.ServiceInterface;

namespace AppointmentManagmentApi.Repository
{
    public class LoginService:ILogin
    {
   
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username); // Query the User table
        }
    }
}
