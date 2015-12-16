using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TimeS.BLL;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.API.Controllers
{
    [RoutePrefix("Atividade")]
    public class AtividadeController : ApiController
    {
        private readonly IAtividadeBLL _atividadeBll = new AtividadeBLL();

        [HttpGet]
        [Route("Gerenciador")]
        public IHttpActionResult GetAtividades()
        {
            var atividades = _atividadeBll.GetAtividades();
            if (!atividades.Any())
                return NotFound();
            return Ok(atividades);
        }

        [HttpGet]
        [Route("Gerenciador/{id}")]
        [ResponseType(typeof(Atividade))]
        public IHttpActionResult GetAtividade(int Id)
        {
            Atividade atividade = _atividadeBll.GetAtividade(Id);
            if (atividade==null)
                return NotFound();
            return Ok(atividade);
        }

        [HttpPost]
        [Route("Gerenciador")]
        public IHttpActionResult PostAtividade(AtividadeViewModel atividade)
        {
            var novaAtividade = _atividadeBll.AddAtividade(atividade);
            if (novaAtividade == null)
                return NotFound();
            return Ok(novaAtividade);
        }

        [HttpPut]
        [Route("Gerenciador")]
        public IHttpActionResult PutAtividade(AtividadeViewModel atividade)
        {
            if (_atividadeBll.EditarAtividade(atividade) == null)
                return NotFound();
            return Ok(atividade);
        }

        [HttpDelete]
        [Route("Gerenciador")]
        public IHttpActionResult DeleteAtividade(int Id)
        {
            bool result = _atividadeBll.DeleteAtividade(Id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
