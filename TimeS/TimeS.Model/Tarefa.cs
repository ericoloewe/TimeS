using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeS.Model
{
    public enum Status
    {
        Finalizado,Cancelado,Pendente,Andamento
    }
    public class Tarefa
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public DateTime Inicio { get; set; }
        [Required]
        public DateTime Entrega { get; set; }
        [Required]
        public Status? Status { get; set; }
        public virtual Usuario Responsavel { get; set; }

        public virtual ICollection<Tempo> Tempo { get; set; }
        public virtual ICollection<Usuario> Seguidores { get; set; }
    }
}