using appFGE.Models;
using appFGE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appFGE.Controllers
{
    [ApiController]
    [Route("api/roles/")]
    public class RoleController : ControllerBase
    {
        public readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            try
            {
                return Ok(await _roleRepository.GetAllRoles());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole([FromBody] Role role)
        {
            try
            {
                await _roleRepository.CreateRole(role);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole([FromBody] Role role, int id)
        {
            try
            {
                await _roleRepository.UpdateRole(role, id);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("delete/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                await _roleRepository.DeleteRole(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
} 