using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using appFGE.Connections;
using appFGE.Models;
using appFGE.Repository;
using Microsoft.IdentityModel.Tokens;

namespace appFGE.Services
{
    public class LoginServices : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;
        private User user;
        private Session session = new Session
            {
                ses_usr_id = 0,
                ses_jwt = string.Empty,
                ses_ip = string.Empty,
                ses_browser = string.Empty,
                ses_expiration_time = null,
            };

        public LoginServices(ApplicationDbContext context, IConfiguration configuration, IUserRepository userRepository,
        ISessionRepository sessionRepository, IRoleRepository roleRepository)
        {
            this._context = context;
            this._sessionRepository = sessionRepository;
            this._configuration = configuration;
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
        }

        public async Task<string> Authentication(Login login)
        {
            try
            {
                bool isAuthenticaded = Login(login);

                if (isAuthenticaded)
                {
                    (session.ses_jwt, session.ses_expiration_time) = GenerateJwt(login);
                    await _sessionRepository.CreateSession(session);
                    return session.ses_jwt;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Login(Login login)
        {
            try
            {
                user = _userRepository.GetUserByUsername(login.log_username).Result;

                if (user != null)
                {
                    session.ses_usr_id = user.usr_id;
                    string hashedUserInput = Security.HashPassword(login.log_password, user.usr_salt);
                    return user.usr_password == hashedUserInput;
                }

                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public (string, DateTime) GenerateJwt(Login loginRequest)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, loginRequest.log_username),
                    new Claim(ClaimTypes.Role, _roleRepository.GetRoleNameById(user.usr_rol_id).Result)
                }),
                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationMinutes"])),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return (jwtToken, tokenDescriptor.Expires.Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}