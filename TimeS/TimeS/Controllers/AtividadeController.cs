using System.Web.Mvc;

namespace TimeS.Controllers
{
    [Authorize]
    public class AtividadeController : Controller
    {
        // GET: Atividade
        public ActionResult Ver()
        {
            return View();
        }

        public ActionResult ListarAtividadesUsuarios()
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