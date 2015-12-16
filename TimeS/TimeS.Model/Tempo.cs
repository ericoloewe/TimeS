using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeS.Model
{
    public class Tempo
    {
        public int Id { get; set; }
        public int Horas { get; set; }
        public DateTime Data { get; set; }
        public int Tarefa_Id { get; set; }
        [ForeignKey("Tarefa_Id")]
        public virtual Tarefa Tarefa { get; set; }
        public string Autor_Id { get; set; }
        [ForeignKey("Autor_Id")]
        public virtual Usuario Autor { get; set; }
    }
}