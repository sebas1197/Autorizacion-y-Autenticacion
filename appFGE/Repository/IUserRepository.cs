using appFGE.Models;

namespace appFGE.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task CreateUser(User user);
        Task UpdateUser(User user, int usr_id);
        Task DeleteUser(int usr_id);
        Task<User> GetUserByUsername(string usr_username);
    }
} 