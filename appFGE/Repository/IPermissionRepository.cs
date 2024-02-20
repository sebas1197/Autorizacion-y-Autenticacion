using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFGE.Models;

namespace appFGE.Repository
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllPermissions();
        Task CreatePermission(Permission per_id);
        Task UpdatePermission(Permission permission, int per_id);
        Task DeletePermission(int per_id);
    }
}