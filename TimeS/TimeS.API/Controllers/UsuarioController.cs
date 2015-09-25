using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeS.BLL;
using TimeS.Model;

namespace TimeS.API.Controllers
{
    [Authorize]
    public class UsuarioController : ApiController
    {
        private IUsuarioBLL userBll = new UsuarioBLL();

        // GET: Usuarios/GetUsuarios/
        [HttpGet]
        [Route("Usuarios/GetUsuarios")]
        [ResponseType(typeof(List<Usuario>))]
        public IHttpActionResult GetUsuarios()
        {
            var usuarios = userBll.GetUsuarios();
            if(!usuarios.Any())
                return NotFound();
            else
            {
                return Ok(usuarios);
            }
        }

        // GET: Usuarios/GetUsuario/
        [HttpGet]
        [Route("Usuarios/GetUsuario/{id}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(string id)
        {
            var usuario = userBll.GetUsuario(id);
            if (usuario==null)
                return NotFound();
            else
            {
                return Ok(usuario);
            }
        }

        // POST: Usuarios/AddUsuario/
        [HttpPost]
        [Route("Usuarios/AddUsuario/")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult AddUsuario(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = userBll.AddUsuario(model);

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }
    }
}
