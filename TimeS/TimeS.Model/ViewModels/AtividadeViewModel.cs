using System.Collections.Generic;

namespace TimeS.Model.ViewModels
{
    public class AtividadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Tipo_Id { get; set; }
        public string Criador_Id { get; set; }
        public string Responsavel_Id { get; set; }

        public virtual List<Tarefa> Tarefas { get; set; }
        public virtual string[] Participantes { get; set; }
    }
}
