using appFGE.Models;
using Microsoft.EntityFrameworkCore;


namespace appFGE.Connections
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Agregar los modelos
        public DbSet<Role> tb_fge_role { get; set; }
        public DbSet<User> tb_fge_user { get; set; }
        public DbSet<Permission> tb_fge_permission { get; set; }
        public DbSet<Assignment> tb_fge_assignment { get; set; }
        public DbSet<Session> tb_fge_sessions { get; set; }
    }
}
