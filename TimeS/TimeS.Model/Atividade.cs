using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeS.Model
{
    public class Atividade
    {
        public Atividade()
        {
            this.Participantes = new HashSet<Usuario>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite algum Nome!")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        [StringLength(200, ErrorMessage = "O tamanho máximo são 200 caracteres.")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Tipo_Id { get; set; }
        public string Criador_Id { get; set; }
        public string Responsavel_Id { get; set; }
        [ForeignKey("Tipo_Id")]
        public virtual TipoAtividade Tipo { get; set; }
        [ForeignKey("Criador_Id")]
        public virtual Usuario Criador { get; set; }
        [ForeignKey("Responsavel_Id")]
        public virtual Usuario Responsavel { get; set; }

        public List<Tarefa> Tarefas { get; set; }
        public virtual ICollection<Usuario> Participantes { get; set; }
    }
}