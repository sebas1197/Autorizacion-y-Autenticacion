using appFGE.Connections;
using appFGE.Repository;
using appFGE.Models;
using Microsoft.EntityFrameworkCore;

namespace appFGE.Services
{
    public class UserService: IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.tb_fge_user.Where(u => u.usr_status == true).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task CreateUser(User user)
        {
            try
            {
                string salt = Security.GenerateSalt();
                string hashedPassword = Security.HashPassword(user.usr_password, salt);
                user.usr_salt = salt;
                user.usr_password = hashedPassword;
                user.usr_registration_date = DateTime.Now;
                user.usr_status = true;

                _context.tb_fge_user.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateUser(User user, int usr_id)
        {
            try
            {
                var userFound = _context.tb_fge_user.Find(usr_id);

                if (userFound != null)
                {
 
                    if(!string.IsNullOrEmpty(user.usr_password))
                    {
                        string salt = Security.GenerateSalt();
                        string hashedPassword = Security.HashPassword(user.usr_password, salt);
                        userFound.usr_salt = salt;
                        userFound.usr_password = hashedPassword;
                    }

                    userFound.usr_fullname = user.usr_fullname;
                    userFound.usr_employee_code = user.usr_employee_code;
                    userFound.usr_position = user.usr_position;
                    userFound.usr_username = user.usr_username;
                    userFound.usr_rol_id = user.usr_rol_id;
                    
                    await _context.SaveChangesAsync(); 
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteUser(int usr_id)
        {
            try
            {
                var userFound = _context.tb_fge_user.Find(usr_id);
                if (userFound != null)
                {
                    userFound.usr_status = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> GetUserByUsername(string usr_username)
        {
            try
            {
                User userFound = await _context.tb_fge_user.Where(u => u.usr_username == usr_username).FirstOrDefaultAsync();
                if (userFound != null)
                {
                    return userFound;
                }
                throw new Exception("Usuario no encontrado");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
 