using System.Linq;
using System.Web.Http;
using TimeS.BLL;

namespace TimeS.API.Controllers
{
    public class AccountController : ApiController
    {
        public IHttpActionResult GetUsuarios()
        {
            IUsuarioBLL userBll = new UsuarioBLL();
            var usuarios = userBll.GetUsuarios();
            if(!usuarios.Any())
                return NotFound();
            else
            {
                return Ok(usuarios);
            }
        }
    }
}
