using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.BLL
{
    public interface IUsuarioBLL
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(string id);
        UsuarioViewModel AddUsuario(RegisterViewModel usuario);
        IdentityRole GetRoleUsuario(string Id);
        UsuarioViewModel EditarUsuario(UsuarioViewModel usuarioView);
        bool DeleteUsuario(string id);
        string ConverterBinaryImageToStringWebImage(byte[] imagem);
        byte[] ConverterStringWebImageToBinaryImage(string imagem);
        Usuario GetUsuarioPorEmail(string Email);
    }
}
