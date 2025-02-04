using AppointmentManagmentApi.Models;

namespace AppointmentManagmentApi.ServiceInterface
{
    public interface IUserService 
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
