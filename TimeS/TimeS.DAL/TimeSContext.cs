using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TimeS.Model;

namespace TimeS.DAL
{
    public class TimeSContext : IdentityDbContext<ApplicationUser>
    {
        public TimeSContext()
            : base("TimeSConnection")
        {
        }

        public static TimeSContext Create()
        {
            return new TimeSContext();
        }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<TipoAtividade> TiposAtividades { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Tempo> Tempos { get; set; }

    }
}
