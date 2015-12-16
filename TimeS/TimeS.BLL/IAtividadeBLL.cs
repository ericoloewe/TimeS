using System.Collections.Generic;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.BLL
{
    public interface IAtividadeBLL
    {
        List<Atividade> GetAtividades();
        Atividade AddAtividade(AtividadeViewModel atividade);
        Atividade EditarAtividade(AtividadeViewModel atividade);
        bool DeleteAtividade(int id);
        Atividade GetAtividade(int id);
    }
}
