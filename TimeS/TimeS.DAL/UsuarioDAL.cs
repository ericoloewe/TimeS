using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeS.Model;

namespace TimeS.DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {
        public List<Usuario> GetUsuarios()
        {
            using (TimeSContext db = new TimeSContext())
            {
                return db.Users.ToList();
            }
        }

        public Usuario GetUsuario(string id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                return db.Users.Find(id);
            }
        }

        public Usuario AddUsuario(RegisterViewModel usuario)
        {
            using (TimeSContext db = new TimeSContext())
            {
                var store = new UserStore<Usuario>(db);
                var manager = new UserManager<Usuario>(store);
                var novousuario = new Usuario() { Nome = usuario.Nome, UserName = usuario.Email, Email = usuario.Email };

                manager.Create(novousuario, usuario.Password);
                manager.AddToRole(novousuario.Id, "Comum");

                return novousuario;
            }
        }
    }
}