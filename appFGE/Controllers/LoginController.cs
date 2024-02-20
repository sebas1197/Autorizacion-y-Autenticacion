
using appFGE.Models;
using appFGE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cuba.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            this._loginRepository = loginRepository;
        }

        [HttpPost]
        public ActionResult Login([FromBody] Login login)
        {
            Console.WriteLine("Login", login.log_username, login.log_password);
            try
            {
                string jwt = _loginRepository.Authentication(login).Result;

                if (!string.IsNullOrEmpty(jwt))
                {
                    return Ok(jwt);
                }

                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}