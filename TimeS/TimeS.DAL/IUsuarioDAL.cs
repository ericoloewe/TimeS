using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeS.Model;

namespace TimeS.DAL
{
    public interface IUsuarioDAL
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(string id);
        Usuario AddUsuario(RegisterViewModel usuario);
        IdentityRole GetRoleUsuario(string id);
        Usuario EditarUsuario(Usuario usuario);
        IdentityRole GetRoleUsuarioPorNome(string prioridade);
        bool DeleteUsuario(string id);
        Usuario GetUsuarioPorEmail(string Email);
    }
}
