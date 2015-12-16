using System.Collections.Generic;

namespace TimeS.Model.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Role { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Atividade> Atividades { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
