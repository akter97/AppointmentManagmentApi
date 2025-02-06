using AppointmentManagmentApi.Models;

namespace AppointmentManagmentApi.ServiceInterface
{
    public interface ILogin
    {
        User GetUserByUsername(string username);
    }

}
