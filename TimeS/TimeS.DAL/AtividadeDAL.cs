using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeS.Model;
namespace TimeS.DAL
{
    class AtividadeDAL : IAtividadeDAL
    {
        public bool CriarAtividade(Atividade atividade)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.Atividades.Add(atividade);
                db.SaveChanges();
                return true;
            }
        }
    }
}
