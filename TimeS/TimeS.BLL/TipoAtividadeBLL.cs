using TimeS.DAL;
using TimeS.Model;

namespace TimeS.BLL
{
    public class TipoAtividadeBLL : ITipoAtividadeBLL
    {
        private ITipoAtividadeDAL tipoAtividadeDal;
        public TipoAtividadeBLL()
        {
            tipoAtividadeDal = new TipoAtividadeDAL();
        }
        public TipoAtividadeBLL(ITipoAtividadeDAL itipoAtividadeDal)
        {
            tipoAtividadeDal = itipoAtividadeDal;
        }
        public bool CriarTipoAtividade(TipoAtividade tipoAtividade)
        {
            return tipoAtividadeDal.CriarTipoAtividade(tipoAtividade);
        }
    }
}