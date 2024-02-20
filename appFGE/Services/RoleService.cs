using appFGE.Connections;
using appFGE.Repository;
using appFGE.Models;
using Microsoft.EntityFrameworkCore;

namespace appFGE.Services
{
    public class RoleService: IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            try
            {
                return await _context.tb_fge_role.Where(r => r.rol_status == true).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
 
        public async Task CreateRole(Role role)
        {
            try
            {
                role.rol_status = true;
                _context.tb_fge_role.Add(role);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateRole(Role role, int rol_id)
        {
            try
            {
                var roleFound = _context.tb_fge_role.Find(rol_id);

                if (roleFound != null)
                {
                    roleFound.rol_name = role.rol_name;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteRole(int rol_id)
        {
            try
            { 
                var roleFound = _context.tb_fge_role.Find(rol_id);
                
                if (roleFound != null)
                {
                    roleFound.rol_status = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> GetRoleNameById(int rol_id)
        {
            try
            {
                Role roleFound = await _context.tb_fge_role.Where(r => r.rol_id == rol_id).FirstOrDefaultAsync();
                return roleFound.rol_name;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}