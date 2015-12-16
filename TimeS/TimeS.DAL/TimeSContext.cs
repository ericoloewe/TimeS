using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TimeS.Model;

namespace TimeS.DAL
{
    public class TimeSContext : IdentityDbContext<Usuario>
    {
        public TimeSContext() : base("TimeSConnection")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Database.SetInitializer<TimeSContext>(new TimeSDBInitializer());
            Configuration.ProxyCreationEnabled = false;
        }

        public static TimeSContext Create()
        {
            return new TimeSContext();
        }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<TipoAtividade> TiposAtividades { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Tempo> Tempos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("RolesUsuario");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("LoginsUsuario");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("ClaimsUsuario");

            modelBuilder.Entity<Usuario>().
                HasMany(c => c.Atividades).
                WithMany(p => p.Participantes).
                Map(
                    m =>
                    {
                        m.MapRightKey("Atividade_Id");
                        m.MapLeftKey("Usuario_Id");
                        m.ToTable("ParticipantesAtividades");
                    });
            modelBuilder.Entity<Tarefa>().
                HasMany(c => c.Seguidores).
                WithMany(p => p.Tarefas).
                Map(
                    m =>
                    {
                        m.MapRightKey("Usuario_Id");
                        m.MapLeftKey("Tarefa_Id");
                        m.ToTable("SeguidoresTarefas");
                    });
        }

    }
}
