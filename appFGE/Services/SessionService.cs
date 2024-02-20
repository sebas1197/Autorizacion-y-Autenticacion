using appFGE.Connections;
using appFGE.Repository;
using appFGE.Models;
using Microsoft.EntityFrameworkCore;

namespace appFGE.Services
{
    public class SessionService: ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Session>> GetAllSessions()
        {
            try
            {
                return await _context.tb_fge_sessions.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task CreateSession(Session session)
        {
            try
            {   
                session.ses_date_time = DateTime.Now;
                session.ses_status = true;

                // TODO: Get real IP and real Browser
                session.ses_ip = "192.168.0.0";
                session.ses_browser = "Chrome";

                _context.tb_fge_sessions.Add(session);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}