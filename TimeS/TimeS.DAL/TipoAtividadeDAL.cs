using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeS.Model;

namespace TimeS.DAL
{
    public class TipoAtividadeDAL : ITipoAtividadeDAL
    {
        public bool CriarTipoAtividade(TipoAtividade tipoAtividade)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.TiposAtividades.Add(tipoAtividade);
                db.SaveChanges();
                return true;
            }
        }
    }
}
