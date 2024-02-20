using appFGE.Models;
using appFGE.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace appFGE.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        private Security security;

        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            this._configuration = configuration;
            security = new Security(_configuration);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                // if(!security.ValidateJwt(Request.Headers["Authorization"]))
                //     return BadRequest("JWT inválido");

                // if(!security.GetRoleFromJWT(Request.Headers["Authorization"], "super"))
                //     return BadRequest("Su Rol no cumple con los permisos necesarios");

                return Ok(await _userRepository.GetAllUsers()); 
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                await _userRepository.CreateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser([FromBody] User user, int id)
        {
            try
            {
                await _userRepository.UpdateUser(user, id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteUser(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
