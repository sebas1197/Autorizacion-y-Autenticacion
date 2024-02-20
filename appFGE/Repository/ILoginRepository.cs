using appFGE.Models;

namespace appFGE.Repository
{
    public interface ILoginRepository
    {
         Task<string> Authentication(Login login);
         bool Login(Login login);
    }
} 