using appFGE.Models;

namespace appFGE.Repository
{
    public interface ISessionRepository
    {
        Task<List<Session>> GetAllSessions();
        Task CreateSession(Session session);
    }
}