using System.Collections.Generic;
using TimeS.Model;

namespace TimeS.BLL
{
    public interface ITipoAtividadeBLL
    {
        List<TipoAtividade> GetTipoAtividades();
        TipoAtividade AddTipoAtividade(TipoAtividade tipoatividade);
        TipoAtividade EditarTipoAtividade(TipoAtividade tipoatividade);
        bool DeleteTipoAtividade(int id);
    }
}