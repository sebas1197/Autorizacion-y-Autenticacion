using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFGE.Models;

namespace appFGE.Repository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();
        Task CreateRole(Role rol_id);
        Task UpdateRole(Role role, int rol_id);
        Task DeleteRole(int rol_id);
        Task<string> GetRoleNameById(int rol_id);
    }
} 