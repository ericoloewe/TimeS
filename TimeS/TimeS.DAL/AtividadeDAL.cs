using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Identity;
using TimeS.Model;

namespace TimeS.DAL
{
    public class AtividadeDAL : IAtividadeDAL
    {
        public List<Atividade> GetAtividades()
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    return db.Atividades
                        .Include(a => a.Tipo)
                        .Include(a => a.Responsavel)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return null;
                }
            }
        }

        public Atividade AddAtividade(Atividade atividade)
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    var participantes = new List<string>();
                    atividade.Participantes.ToList().ForEach(u => participantes.Add(u.Id));
                    atividade.Participantes = new List<Usuario>();
                    db.Atividades.Add(atividade);
                    db.SaveChanges();
                    AddAtividadeAosUsuarios(
                        db.Atividades.First(a => (a.Nome == atividade.Nome && a.Tipo_Id == atividade.Tipo_Id)),
                        participantes);
                    return db.Atividades.First(a => (a.Nome == atividade.Nome && a.Tipo_Id == atividade.Tipo_Id));
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return null;
                }
            }
        }

        public void AddAtividadeAosUsuarios(Atividade atividade, List<string> participantes)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.Atividades.Attach(atividade);
                foreach (var participante in participantes)
                {
                    Usuario usuario = db.Users.Include(u => u.Atividades).First(u => u.Id.Equals(participante));
                    if (usuario != null)
                    {
                        if (usuario.Atividades.All(t => t.Id != atividade.Id))
                        {
                            usuario.Atividades.Add(atividade);
                            db.Entry(usuario).State = EntityState.Modified;
                        }
                        db.SaveChanges();
                    }
                }
            }
        }

        public void RemoveUsuariosAtividades(Atividade atividade, List<string> participantes)
        {
            using (TimeSContext db = new TimeSContext())
            {
                var usuariosParticipantes = new List<Usuario>();
                participantes.ForEach(p => usuariosParticipantes.Add(db.Users.Find(p)));
                var naoMaisPartipantesDaAtividade =
                    db.Atividades
                        .Include(a => a.Participantes)
                        .First(a => a.Id == atividade.Id).Participantes.Except(usuariosParticipantes);
            }
        }

        public Atividade EditarAtividade(Atividade atividade)
        {
            using (TimeSContext db = new TimeSContext())
            {
                //try
                //{
                    List<Tarefa> tarefas = atividade.Tarefas;
                    if (tarefas != null)
                    {
                        tarefas.ForEach(t => t.Atividade_Id = atividade.Id);
                        tarefas.ForEach(t => db.Entry(t).State = t.Id == 0 ? EntityState.Added : EntityState.Modified);
                    }
                    atividade.Participantes.ToList().ForEach(u => db.Users.Attach(u));
                    db.Atividades.Attach(atividade);
                    db.Entry(atividade).State = EntityState.Modified;
                    db.SaveChanges();
                    return db.Atividades.Find(atividade.Id);
                //}
                //catch (Exception ex)
                //{
                //    Debug.WriteLine(ex.Message);
                //    return null;
                //}
            }
        }

        public bool DeleteAtividade(int id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                Atividade atividade = db.Atividades.Include(a => a.Participantes).First(u => u.Id == id);
                atividade.Participantes.ToList().ForEach(u => atividade.Participantes.Remove(u));
                db.Atividades.Remove(atividade);
                db.SaveChanges();
                return (db.Atividades.Find(id) == null);
            }
        }

        public Atividade GetAtividade(int id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    return db.Atividades
                        .Include(a => a.Tipo)
                        .Include(a => a.Participantes)
                        .Include(a => a.Responsavel)
                        .Include(a => a.Criador)
                        .First(a => a.Id == id);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
