using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeS.Model
{
    public class TipoAtividade
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite algum Nome!")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}