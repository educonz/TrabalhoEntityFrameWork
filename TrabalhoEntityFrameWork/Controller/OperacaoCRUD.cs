using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoEntityFrameWork.Model;

namespace TrabalhoEntityFrameWork.Controller
{
    public class OperacaoCRUD<T> where T : class
    {
        private DbContexto db = new DbContexto();

        public int Salvar(T t)
        {
            db.Set<T>().Add(t);
            return SalvarAlteracoesContexto();
        }

        public int Editar(T t)
        {
            db.Entry(t).State = EntityState.Modified;
            return SalvarAlteracoesContexto();
        }

        public int Delete(int id)
        {
            db.Set<T>().Remove(db.Set<T>().Find(id));
            return SalvarAlteracoesContexto();
        }

        public IEnumerable<T> Get()
        {
            return db.Set<T>().ToList();
        }

        private int SalvarAlteracoesContexto()
        {
            return db.SaveChanges();
        }
    }
}
