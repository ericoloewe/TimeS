using System.Collections.Generic;
using TimeS.Model;

namespace TimeS.DAL
{
    public interface IAtividadeDAL
    {
        List<Atividade> GetAtividades();
        Atividade AddAtividade(Atividade atividade);
        Atividade EditarAtividade(Atividade atividade);
        bool DeleteAtividade(int id);
        Atividade GetAtividade(int id);
    }
}
