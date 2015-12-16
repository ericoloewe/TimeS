using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeS.Model
{
    public enum Status
    {
        Finalizado,Cancelado,Pendente,Andamento
    }
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Entrega { get; set; }
        public Status? Status { get; set; }
        public string Responsavel_Id { get; set; }
        [ForeignKey("Responsavel_Id")]
        public virtual Usuario Responsavel { get; set; }
        
        public int Atividade_Id { get; set; }

        [ForeignKey("Atividade_Id")]
        public virtual Atividade Atividade { get; set; }

        public virtual List<Tempo> Tempo { get; set; }
        public virtual ICollection<Usuario> Seguidores { get; set; }
    }
}