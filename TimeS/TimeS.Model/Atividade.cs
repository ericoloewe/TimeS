using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeS.Model
{
    public class Atividade
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite algum Nome!")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        [StringLength(200, ErrorMessage = "O tamanho máximo são 200 caracteres.")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public virtual TipoAtividade Tipo { get; set; }
        public virtual ApplicationUser Criador { get; set; }
        public virtual ApplicationUser Responsavel { get; set; }

        public virtual ICollection<Tarefa> Tarefas { get; set; }
        public virtual ICollection<ApplicationUser> Participantes { get; set; }
    }
}