using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TimeS.Model
{
    public class Tempo
    {
        public int Id { get; set; }
        [Required]
        public int Horas { get; set; }
        public DateTime Data { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}