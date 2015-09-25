using System.Collections.Generic;
using TimeS.Model;

namespace TimeS.DAL
{
    public interface IUsuarioDAL
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(string id);
        Usuario AddUsuario(RegisterViewModel usuario);
    }
}
