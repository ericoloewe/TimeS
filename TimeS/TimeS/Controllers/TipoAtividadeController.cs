using System.Web.Mvc;

namespace TimeS.Controllers
{
    [Authorize]
    public class TipoAtividadeController : Controller
    {
        // GET: TipoAtividade
        public ActionResult Ver()
        {
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Deletar()
        {
            return View();
        }

        public ActionResult Detalhes()
        {
            return View();
        }

        public ActionResult Nova()
        {
            return View();
        }
    }
}