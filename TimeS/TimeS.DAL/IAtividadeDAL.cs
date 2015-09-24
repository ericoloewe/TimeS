using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TimeS.Model;

namespace TimeS.DAL
{
    public interface IAtividadeDAL
    {
        bool CriarAtividade(Atividade atividade);
    }
}
