using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TimeS.BLL;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.API.Controllers
{
    [RoutePrefix("Atividade/{atividadeId}/Tarefa")]
    public class TarefaController : ApiController
    {
        private readonly ITarefaBLL _tarefaBll = new TarefaBLL();

        [HttpGet]
        [Route("Gerenciador")]
        public IHttpActionResult GetTarefas(int atividadeId)
        {
            List<Tarefa> tarefas = _tarefaBll.GetTarefas(atividadeId);
            List<object> listaTarefas = new List<object>();

            if (!tarefas.Any())
                return NotFound();

            tarefas.ForEach(
                t => listaTarefas.Add(new 
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    Descricao = t.Descricao,
                    Inicio = t.Inicio!=null?t.Inicio.Value.ToShortDateString():"",
                    Hora_Inicio = t.Inicio!=null?t.Inicio.Value.ToShortTimeString():"",
                    Hora_Entrega = t.Entrega!=null?t.Entrega.Value.ToShortTimeString():"",
                    Entrega = t.Entrega!=null?t.Entrega.Value.ToShortDateString():"",
                    Status = Convert.ToString(t.Status),
                    Status_Id = Convert.ToInt32(t.Status),
                    Seguidores = t.Seguidores,
                    Tempo = t.Tempo
                }
                )
            );
            return Ok(listaTarefas);
        }

        [HttpGet]
        [Route("Gerenciador/{tarefaid}")]
        public IHttpActionResult GetTarefa(int atividadeId, int tarefaid)
        {
            Tarefa tarefa = _tarefaBll.GetTarefa(atividadeId, tarefaid);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        [Route("Gerenciador")]
        public IHttpActionResult PostTarefa(int atividadeId, TarefaViewModel tarefa)
        {
            Tarefa novaTarefa = _tarefaBll.AddTarefa(atividadeId,tarefa);
            if (novaTarefa == null)
                return NotFound();
            return Ok(novaTarefa);
        }

        [HttpPost]
        [Route("Gerenciador/{tarefaId}/Tempo")]
        public IHttpActionResult PostTempoTarefa(int atividadeId,int tarefaId, TempoViewModel tempo)
        {
            Tempo novoTempo = _tarefaBll.AddTempoTarefa(atividadeId,tarefaId, tempo);
            if (novoTempo == null)
                return NotFound();
            return Ok(novoTempo);
        }

        [HttpPut]
        [Route("Gerenciador")]
        public IHttpActionResult PutAtividade(int atividadeId, TarefaViewModel tarefa)
        {
            if (_tarefaBll.EditarTarefa(atividadeId, tarefa) == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpDelete]
        [Route("Gerenciador")]
        public IHttpActionResult DeleteTarefa(int atividadeId, int Id)
        {
            bool result = _tarefaBll.DeletarTarefa(Id);
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpGet]
        [Route("GetStatus")]
        public IHttpActionResult GetStatus()
        {
            var status = new List<object>();
            foreach (var item in Enum.GetValues(typeof(Status)))
            {
                status.Add(new
                {
                    Id = (int)item,
                    Nome = item.ToString()
                });
            }
            return Ok(status);
        }
    }
}
