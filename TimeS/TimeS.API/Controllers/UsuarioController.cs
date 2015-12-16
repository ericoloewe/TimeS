using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TimeS.BLL;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.API.Controllers
{
    [RoutePrefix("Usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioBLL _usuarioBll = new UsuarioBLL();

        [HttpGet]
        [Route("Gerenciador")]
        [ResponseType(typeof(UsuarioViewModel))]
        public IHttpActionResult GetUsuarios()
        {
            var usuarios = _usuarioBll.GetUsuarios().Select(u => new
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Role = _usuarioBll.GetRoleUsuario(u.Roles.First().RoleId).Name,
                Foto = _usuarioBll.ConverterBinaryImageToStringWebImage(u.Foto),
                Atividades = u.Atividades,
                Ativo = u.Ativo
            }).ToList();

            if(!usuarios.Any())
                return NotFound();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Gerenciador/{Id}")]
        [ResponseType(typeof(UsuarioViewModel))]
        public IHttpActionResult GetUsuario(string Id)
        {
            Usuario usuario = _usuarioBll.GetUsuario(Id);
            UsuarioViewModel viewmodelusuario = new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = _usuarioBll.GetRoleUsuario(usuario.Roles.First().RoleId).Name,
                Foto = _usuarioBll.ConverterBinaryImageToStringWebImage(usuario.Foto),
                Ativo = usuario.Ativo,
                Atividades = usuario.Atividades,
                Tarefas = usuario.Tarefas
            };
            if (usuario == null)
                return NotFound();
            return Ok(viewmodelusuario);
        }

        [HttpPost]
        [Route("Gerenciador")]
        public IHttpActionResult PostUsuario(RegisterViewModel usuario)
        {
            var novoUsuario = _usuarioBll.AddUsuario(usuario);
            if (novoUsuario == null)
                return NotFound();
            return Ok(novoUsuario);
        }

        [HttpPut]
        [Route("Gerenciador")]
        public IHttpActionResult PutUsuario(UsuarioViewModel usuario)
        {
            if (_usuarioBll.EditarUsuario(usuario) == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpDelete]
        [Route("Gerenciador")]
        public IHttpActionResult DeleteUsuario(string Id)
        {
            bool result = _usuarioBll.DeleteUsuario(Id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
