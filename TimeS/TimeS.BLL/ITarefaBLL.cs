using System.Collections.Generic;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.BLL
{
    public interface ITarefaBLL
    {
        List<Tarefa> GetTarefas(int atividadeId);
        Tarefa GetTarefa(int atividadeId, int id);
        Tarefa AddTarefa(int atividadeId, TarefaViewModel tarefa);
        bool DeletarTarefa(int id);
        Tarefa EditarTarefa(int atividadeId, TarefaViewModel tarefa);
        Tempo AddTempoTarefa(int atividadeId, int tarefaId, TempoViewModel tempo);
    }
}
