using System.Collections.Generic;
using TimeS.DAL;
using TimeS.Model;

namespace TimeS.BLL
{
    public class TipoAtividadeBLL : ITipoAtividadeBLL
    {
        private readonly ITipoAtividadeDAL _tipoatividadeDal = new TipoAtividadeDAL();
        public List<TipoAtividade> GetTipoAtividades()
        {
            return _tipoatividadeDal.GetTipoAtividades();
        }

        public TipoAtividade AddTipoAtividade(TipoAtividade tipoatividade)
        {
            return _tipoatividadeDal.AddTipoAtividade(tipoatividade);
        }

        public TipoAtividade EditarTipoAtividade(TipoAtividade tipoatividade)
        {
            return _tipoatividadeDal.EditarTipoAtividade(tipoatividade);
        }

        public bool DeleteTipoAtividade(int id)
        {
            return _tipoatividadeDal.DeleteTipoAtividade(id);
        }
    }
}