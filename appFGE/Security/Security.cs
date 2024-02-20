
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using appFGE.Models;
using appFGE.Repository;
using Microsoft.IdentityModel.Tokens;


public class Security
{

    private readonly IConfiguration _configuration;

    public Security(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public static string GenerateSalt()
    {
        try
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static string HashPassword(string password, string salt)
    {
        try
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public bool ValidateJwt(string jwtToken)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool GetRoleFromJWT(string jwtToken, string expectedRole)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            var claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);

            // Busca el reclamo de rol en los Claims del token
            var roleClaim = claimsPrincipal.FindFirst(ClaimTypes.Role);

            // Check si el roleClaim no es nulo antes de comparar
            return roleClaim?.Value == expectedRole;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


}
