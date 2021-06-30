using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Repository
{
   public interface IRepository<T>
    {

        List<T> List();
        int Save();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Delete(int Id);
        T GetById(int Id);
    }
}
