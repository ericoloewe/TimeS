using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeS.Model;
using System.Web;

namespace TimeS.DAL
{
    class TimeSDBInitializer : CreateDatabaseIfNotExists<TimeSContext>
    {
        protected override void Seed(TimeSContext context)
        {
            base.Seed(context);
            var store = new UserStore<Usuario>(context);
            var manager = new UserManager<Usuario>(store);

            var regras = new List<IdentityRole>
            {
                new IdentityRole {
                    Name = "Administrador"
                },
                new IdentityRole {
                    Name = "Comum"
                }
            };
            var storeRole = new RoleStore<IdentityRole>(context);
            var managerRole = new RoleManager<IdentityRole>(storeRole);

            regras.ForEach(r => managerRole.Create(r));

            var usuarios = new List<Usuario>
            {
                new Usuario {
                    Nome = "Administrador Geral",
                    UserName = "admin@s2b.com",
                    Email = "admin@s2b.com",
                    Foto = getFileBytes("\\Media\\img\\pic\\S2BUser.jpg"),
                    ImageMimeType = "image/jpeg"
                }
            };

            foreach (Usuario usuario in usuarios)
            {
                manager.Create(usuario, "pass@word1");
                manager.AddToRole(usuario.Id, "Administrador");
            }

            var tipoatividademanager = new TipoAtividadeDAL();

            var tiposAtividades = new List<TipoAtividade>
            {
                new TipoAtividade
                {
                    Nome = "Projeto",
                    Descricao = "Projeto é um tipo basico de atidade."
                },
                new TipoAtividade
                {
                    Nome = "Reunião",
                    Descricao = "Reunião é um tipo basico de atidade."
                }
            };

            tiposAtividades.ForEach(t => tipoatividademanager.CriarTipoAtividade(t));
        }

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
    }
}
