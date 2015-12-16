using System.Collections.Generic;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.DAL
{
    public interface ITarefaDAL
    {
        List<Tarefa> GetTarefas(int atividadeId);
        Tarefa GetTarefa(int atividadeId, int id);
        Tarefa AddTarefa(Tarefa tarefa);
        bool DeletarTarefa(int id);
        Tarefa EditarTarefa(Tarefa tarefa);
        Tempo AddTempoTarefa(Tempo tempo);
    }
}
