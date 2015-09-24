using System.Collections.Generic;
using TimeS.DAL;
using TimeS.Model;

namespace TimeS.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private IUsuarioDAL usuarioDal;
        public UsuarioBLL()
        {
            usuarioDal = new UsuarioDAL();
        }
        public UsuarioBLL(IUsuarioDAL iUsuarioDal)
        {
            usuarioDal = iUsuarioDal;
        }
        public List<Usuario> GetUsuarios()
        {
            return usuarioDal.GetUsuarios();
        }
    }
}
