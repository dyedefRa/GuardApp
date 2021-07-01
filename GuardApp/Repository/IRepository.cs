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
        bool Save();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(int Id);
        T GetById(int Id);
    }
}
