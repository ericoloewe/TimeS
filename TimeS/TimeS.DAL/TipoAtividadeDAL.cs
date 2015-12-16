using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using TimeS.Model;

namespace TimeS.DAL
{
    public class TipoAtividadeDAL : ITipoAtividadeDAL
    {
        public List<TipoAtividade> GetTipoAtividades()
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    return db.TiposAtividades.ToList();
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return null;
                }
            }
        }

        public TipoAtividade AddTipoAtividade(TipoAtividade tipoatividade)
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    db.TiposAtividades.Add(tipoatividade);
                    db.SaveChanges();
                    return tipoatividade;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return null;
                }
            }
        }

        public TipoAtividade EditarTipoAtividade(TipoAtividade tipoatividade)
        {
            using (TimeSContext db = new TimeSContext())
            {
                try
                {
                    db.Entry(tipoatividade).State = EntityState.Modified;
                    db.SaveChanges();
                    return tipoatividade;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return null;
                }
            }
        }

        public bool DeleteTipoAtividade(int id)
        {
            using (TimeSContext db = new TimeSContext())
            {
                db.TiposAtividades.Remove(db.TiposAtividades.Find(id));
                db.SaveChanges();
                return (db.TiposAtividades.Find(id) == null);
            }
        }
    }
}
