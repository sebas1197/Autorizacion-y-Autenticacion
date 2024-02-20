using appFGE.Models;
using appFGE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appFGE.Controllers
{
    [ApiController]
    [Route("api/permissions/")]
    public class PermissionController : ControllerBase
    {
        public readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            this._permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Permission>>> GetAllPermissions()
        {
            try
            {
                return Ok(await _permissionRepository.GetAllPermissions());
            }
            catch (Exception e) 
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreatePermission([FromBody] Permission permission)
        {
            try
            {
                await _permissionRepository.CreatePermission(permission);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePermission([FromBody] Permission permission, int id)
        {
            try
            {
                await _permissionRepository.UpdatePermission(permission, id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("delete/{id}")]
        public async Task<ActionResult> DeletePermission(int id)
        {
            try
            {
                await _permissionRepository.DeletePermission(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}