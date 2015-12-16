using System.Collections.Generic;
using TimeS.Model;

namespace TimeS.DAL
{
    public interface ITipoAtividadeDAL
    {
        List<TipoAtividade> GetTipoAtividades();
        TipoAtividade AddTipoAtividade(TipoAtividade tipoatividade);
        TipoAtividade EditarTipoAtividade(TipoAtividade tipoatividade);
        bool DeleteTipoAtividade(int id);
    }
}
