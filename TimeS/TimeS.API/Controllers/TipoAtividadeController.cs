using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TimeS.BLL;
using TimeS.Model;

namespace TimeS.API.Controllers
{
    [RoutePrefix("TipoAtividade")]
    public class TipoAtividadeController : ApiController
    {
        private readonly ITipoAtividadeBLL _tipoatividadeBll = new TipoAtividadeBLL();

        [HttpGet]
        [Route("Gerenciador")]
        [ResponseType(typeof(TipoAtividade))]
        public IHttpActionResult GetTipoAtividades()
        {
            List<TipoAtividade> tipoatividades = _tipoatividadeBll.GetTipoAtividades();
            if (!tipoatividades.Any())
                return NotFound();
            return Ok(tipoatividades);
        }

        [HttpPost]
        [Route("Gerenciador")]
        public IHttpActionResult PostTipoAtividade(TipoAtividade tipoatividade)
        {
            TipoAtividade novoTipoAtividade = _tipoatividadeBll.AddTipoAtividade(tipoatividade);
            if (novoTipoAtividade == null)
                return NotFound();
            return Ok(novoTipoAtividade);
        }

        [HttpPut]
        [Route("Gerenciador")]
        public IHttpActionResult PutTipoAtividade(TipoAtividade tipoatividade)
        {
            if (_tipoatividadeBll.EditarTipoAtividade(tipoatividade) == null)
                return NotFound();
            return Ok(tipoatividade);
        }

        [HttpDelete]
        [Route("Gerenciador")]
        public IHttpActionResult DeleteTipoAtividade(int Id)
        {
            bool result = _tipoatividadeBll.DeleteTipoAtividade(Id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
