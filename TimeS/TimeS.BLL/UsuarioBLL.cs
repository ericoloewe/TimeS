using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeS.DAL;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly IUsuarioDAL _usuarioDal;
        public UsuarioBLL()
        {
            _usuarioDal = new UsuarioDAL();
        }
        public UsuarioBLL(IUsuarioDAL iUsuarioDal)
        {
            _usuarioDal = iUsuarioDal;
        }
        public List<Usuario> GetUsuarios()
        {
            return _usuarioDal.GetUsuarios();
        }

        public Usuario GetUsuario(string id)
        {
            return _usuarioDal.GetUsuario(id);
        }

        public UsuarioViewModel AddUsuario(RegisterViewModel usuario)
        {
            Usuario novoUsuario =  _usuarioDal.AddUsuario(usuario);
            if (novoUsuario != null)
                return new UsuarioViewModel
                {
                    Id = novoUsuario.Id,
                    Nome = novoUsuario.Nome,
                    Email = novoUsuario.Email,
                    Role = _usuarioDal.GetRoleUsuario(novoUsuario.Roles.FirstOrDefault().RoleId).Name,
                    Foto = ConverterBinaryImageToStringWebImage(novoUsuario.Foto),
                    Ativo = novoUsuario.Ativo
                };
            return null;
        }

        public IdentityRole GetRoleUsuario(string Id)
        {
            return _usuarioDal.GetRoleUsuario(Id);
        }

        public UsuarioViewModel EditarUsuario(UsuarioViewModel usuarioView)
        {
            Usuario usuario = _usuarioDal.GetUsuario(usuarioView.Id);
            usuario.Nome = usuarioView.Nome;
            usuario.Email = usuarioView.Email;
            usuario.UserName = usuarioView.Email;
            usuario.Ativo = usuarioView.Ativo;
            if (usuario.Equals(_usuarioDal.EditarUsuario(usuario)))
                return usuarioView;
            return null;
        }

        public bool DeleteUsuario(string id)
        {
            return _usuarioDal.DeleteUsuario(id);
        }

        public string ConverterBinaryImageToStringWebImage(byte[] imagem)
        {
            return (imagem != null) ? "data:image/jpg;base64," + Convert.ToBase64String(imagem) : "";
        }

        public byte[] ConverterStringWebImageToBinaryImage(string imagem)
        {
            return Convert.FromBase64String(imagem.Substring(imagem.IndexOf(",")));
        }

        public Usuario GetUsuarioPorEmail(string Email)
        {
            return _usuarioDal.GetUsuarioPorEmail(Email);
        }
    }
}
