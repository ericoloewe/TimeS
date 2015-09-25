using System.Collections.Generic;
using TimeS.Model;

namespace TimeS.BLL
{
    public interface IUsuarioBLL
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(string id);
        Usuario AddUsuario(RegisterViewModel usuario);
    }
}
