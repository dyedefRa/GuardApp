using GuardApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _objectSet;
        private readonly Context _context = new Context();

        public Repository()
        {
            _objectSet = _context.Set<T>();
        }
        public int Delete(T entity)
        {
            _objectSet.Remove(entity);
            return Save();
        }

        public int Delete(int Id)
        {
            return Delete(GetById(Id));
        }

        public T GetById(int Id)
        {
            return _objectSet.Find(Id);
        }

        public int Insert(T entity)
        {
            _objectSet.Add(entity);
            return Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _objectSet.AddOrUpdate(entity);
            return Save();
        }
    }
}
