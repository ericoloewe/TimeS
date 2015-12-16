using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TimeS.Model
{
    public class Usuario : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required(ErrorMessage = "Digite algum Nome!")]
        public string Nome { get; set; }
        [DisplayName("Foto")]
        [MaxLength]
        public byte[] Foto { get; set; }
        public string ImageMimeType { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
