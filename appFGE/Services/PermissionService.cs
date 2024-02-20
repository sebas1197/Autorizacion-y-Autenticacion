
using appFGE.Connections;
using appFGE.Repository;
using appFGE.Models;
using Microsoft.EntityFrameworkCore;

namespace appFGE.Services
{
    public class PermissionService: IPermissionRepository
    {
        private readonly ApplicationDbContext _context;
        public PermissionService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Permission>> GetAllPermissions() 
        {
            try 
            {
                return await _context.tb_fge_permission.Where(p => p.per_status == true).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task CreatePermission(Permission permission)
        {
            try
            {
                permission.per_status = true;
                _context.tb_fge_permission.Add(permission);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdatePermission(Permission permission, int per_id)
        {
            try
            {
                var permissionFound = _context.tb_fge_permission.Find(per_id);

                if (permissionFound != null)
                {
                    permissionFound.per_action = permission.per_action;
                    permissionFound.per_rol_id = permission.per_rol_id;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletePermission(int per_id)
        {
            try
            {
                var permissionFound = _context.tb_fge_permission.Find(per_id);
                if (permissionFound != null)
                {
                    permissionFound.per_status = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}