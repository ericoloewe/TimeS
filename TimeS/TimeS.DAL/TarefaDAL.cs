using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeS.Model;

namespace TimeS.DAL
{
    public class TarefaDAL : ITarefaDAL
    {
        public List<Tarefa> GetTarefas(int atividadeId)
        {
            using (TimeSContext db = new TimeSContext())
            {
                return db.Tarefas
                    .Where(t => t.Atividade_Id == atividadeId)
                    .Include(t => t.Tempo)
                    .Include(t => t.Seguidores)
                    .ToList();
            }
        }

        public Tarefa GetTarefa(int atividadeId, int id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                return db.Tarefas
                    .Include(t => t.Tempo)
                    .First(t => t.Id==id);
            }
        }

        public Tarefa AddTarefa(Tarefa tarefa)
        {
            using (TimeSContext db = new TimeSContext())
            {
                var seguidores = new List<string>();
                tarefa.Seguidores.ToList().ForEach(u => seguidores.Add(u.Id));
                tarefa.Seguidores = new List<Usuario>();
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                AddTarefaAosUsuarios(
                    db.Tarefas.First(t => t.Atividade_Id == tarefa.Atividade_Id && t.Nome == tarefa.Nome), seguidores);
                return db.Tarefas.First(t => t.Atividade_Id == tarefa.Atividade_Id && t.Nome == tarefa.Nome);
            }
        }

        public void AddTarefaAosUsuarios(Tarefa tarefa,List<string> seguidores)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.Tarefas.Attach(tarefa);
                foreach (var seguidor in seguidores)
                {
                    Usuario usuario = db.Users.Include(u => u.Tarefas).First(u => u.Id.Equals(seguidor));
                    if (usuario != null)
                    {
                        if (usuario.Tarefas.All(t => t.Id != tarefa.Id))
                        {
                            usuario.Tarefas.Add(tarefa);
                            db.Entry(usuario).State = EntityState.Modified;   
                        }
                        db.SaveChanges();
                    }
                }
            }
        }

        public void DetachSeguidoresTarefas(List<Usuario> seguidores)
        {
            using (TimeSContext db = new TimeSContext())
            {
                seguidores.ForEach(u => db.Entry(db.Users.Find(u.Id)).State = EntityState.Detached);
            }
        }

        public void AtualizaSeguidoresTarefas(List<string> seguidores, Tarefa tarefa)
        {
            using (TimeSContext db = new TimeSContext())
            {
                seguidores.ForEach(u => db.Entry(db.Users.Find(u)).State = EntityState.Modified);
                seguidores.ForEach(u => db.Users.Attach(db.Users.Find(u)));
                db.SaveChanges();
            }
        }

        public bool DeletarTarefa(int id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                Tarefa tarefas = db.Tarefas.Include(a => a.Seguidores).First(t => t.Id == id);
                tarefas.Seguidores.ToList().ForEach(u => tarefas.Seguidores.Remove(u));
                db.Tarefas.Remove(tarefas);
                db.SaveChanges();
                return (db.Tarefas.Find(id) == null);
            }
        }

        public Tarefa EditarTarefa(Tarefa tarefa)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.Tarefas.Include(t => t.Seguidores)
                    .First(t => t.Id.Equals(tarefa.Id))
                    .Seguidores.ToList()
                    .ForEach(
                        u =>
                            db.Tarefas.Include(t => t.Seguidores)
                                .First(t => t.Id.Equals(tarefa.Id))
                                .Seguidores.Remove(u)
                    );

                db.Tarefas.Remove(db.Tarefas.Include(t => t.Seguidores).First(t => t.Id.Equals(tarefa.Id)));
                db.SaveChanges();
            }
            using (TimeSContext db = new TimeSContext())
            {
                tarefa.Id = 0;
                tarefa.Seguidores.ToList().ForEach(u => db.Users.Attach(u));
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                return tarefa;
            }
        }

        public Tempo AddTempoTarefa(Tempo tempo)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.Tempos.Add(tempo);
                db.SaveChanges();
                return tempo;
            }
        }
    }
}
