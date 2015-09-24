using System;
using System.ComponentModel.DataAnnotations;

namespace TimeS.Model
{
    public class Tempo
    {
        public int Id { get; set; }
        [Required]
        public int Horas { get; set; }
        public DateTime Data { get; set; }
        public virtual Usuario Author { get; set; }
    }
}