using System;
using System.Collections.Generic;
using System.Linq;
using TimeS.DAL;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.BLL
{
    public class TarefaBLL : ITarefaBLL
    {
        private readonly ITarefaDAL _tarefaDal = new TarefaDAL();
        public List<Tarefa> GetTarefas(int atividadeId)
        {
            return _tarefaDal.GetTarefas(atividadeId);
        }

        public Tarefa GetTarefa(int atividadeId, int id)
        {
            return _tarefaDal.GetTarefa(atividadeId,id);
        }

        public Tarefa AddTarefa(int atividadeId, TarefaViewModel tarefa)
        {
            IUsuarioDAL usuarioDal = new UsuarioDAL();
            Tarefa novaTarefa = new Tarefa()
            {
                Nome = tarefa.Nome,
                Descricao = tarefa.Descricao,
                Inicio = Convert.ToDateTime(tarefa.Inicio+" "+tarefa.Hora_Inicio),
                Entrega = Convert.ToDateTime(tarefa.Entrega + " " + tarefa.Hora_Entrega),
                Atividade_Id = atividadeId,
                Status = (Status) tarefa.Status_Id,
                Responsavel_Id = tarefa.Responsavel_Id
            };
            novaTarefa.Seguidores = new List<Usuario>();
            if (tarefa.Seguidores != null)
                tarefa.Seguidores.ToList()
                    .ForEach(
                        s => novaTarefa.Seguidores.Add(usuarioDal.GetUsuario(s))
                    );
            return _tarefaDal.AddTarefa(novaTarefa);
        }

        public bool DeletarTarefa(int id)
        {
            return _tarefaDal.DeletarTarefa(id);
        }

        public Tarefa EditarTarefa(int atividadeId, TarefaViewModel tarefa)
        {
            IUsuarioDAL usuarioDal = new UsuarioDAL();
            Tarefa tarefaEditada = new Tarefa()
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                Descricao = tarefa.Descricao,
                Inicio = Convert.ToDateTime(tarefa.Inicio + " " + tarefa.Hora_Inicio),
                Entrega = Convert.ToDateTime(tarefa.Entrega + " " + tarefa.Hora_Entrega),
                Atividade_Id = atividadeId,
                Status = (Status)tarefa.Status_Id,
                Responsavel_Id = tarefa.Responsavel_Id,
            };
            tarefaEditada.Seguidores = new List<Usuario>();
            if (tarefa.Seguidores != null)
                tarefa.Seguidores.ToList()
                    .ForEach(
                        s => tarefaEditada.Seguidores.Add(usuarioDal.GetUsuario(s))
                    );
            return _tarefaDal.EditarTarefa(tarefaEditada);
        }

        public Tempo AddTempoTarefa(int atividadeId, int tarefaId, TempoViewModel tempo)
        {
            int horas = TimeSpan.Parse(tempo.Horas).Hours;
            var novoTempo = new Tempo()
            {
                Data = DateTime.Now,
                Tarefa_Id = tarefaId,
                Horas = horas,
                Autor_Id = tempo.Autor_Id
            };
            return _tarefaDal.AddTempoTarefa(novoTempo);
        }
    }
}