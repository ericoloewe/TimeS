using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
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
                try
                {
                    return db.Users
                        .Include(u => u.Roles)
                        .ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public Usuario GetUsuario(string id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    return db.Users
                        .Include(u => u.Roles)
                        .Include(u => u.Atividades)
                        .Include(u => u.Tarefas)
                        .First(u => u.Id.Equals(id));
                }
                catch
                {
                    return null;
                }
                
            }
        }

        public Usuario AddUsuario(RegisterViewModel usuario)
        {
            using (TimeSContext db = new TimeSContext())
            {
                byte[] img;
                try
                {
                    img = ConverterStringWebImageToBinaryImage(usuario.Foto);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    img = getFileBytes("\\Media\\img\\pic\\Storm-Trooper.jpg");
                }
                //byte[] img = getFileBytes("\\Media\\img\\pic\\Storm-Trooper.jpg");
                var store = new UserStore<Usuario>(db);
                var manager = new UserManager<Usuario>(store);
                var novousuario = new Usuario() { Nome = usuario.Nome, UserName = usuario.Email, Email = usuario.Email, Foto = img, Ativo=true };
                try
                {
                    manager.Create(novousuario, usuario.Password);
                    manager.AddToRole(novousuario.Id, "Comum");
                    return novousuario;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return null;
                }
                
            }
        }

        private byte[] ConverterStringWebImageToBinaryImage(string imagem)
        {
            return Convert.FromBase64String(imagem.Substring(imagem.IndexOf(",")));
        }

        public IdentityRole GetRoleUsuario(string id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                return db.Roles.Find(id);
            }
        }

        public Usuario EditarUsuario(Usuario usuario)
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return usuario;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return null;
                }
            }
        }

        public IdentityRole GetRoleUsuarioPorNome(string prioridade)
        {
            using (TimeSContext db = new TimeSContext())
            {
                return db.Roles.First(r => r.Name == prioridade);
            }
        }

        public bool DeleteUsuario(string id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.Users.Remove(db.Users.Find(id));
                db.SaveChanges();
                return (db.Users.Find(id) == null);
            }
        }

        public Usuario GetUsuarioPorEmail(string Email)
        {
            using (TimeSContext db = new TimeSContext())
            {
                return db.Users
                    .Include(u => u.Roles)
                    .First(u => u.Email==Email);
            }
        }

        #region Helpers
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
        #endregion
    }
}