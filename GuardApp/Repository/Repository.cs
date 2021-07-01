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
        public bool Delete(T entity)
        {
            _objectSet.Remove(entity);
            return Save();
        }

        public bool Delete(int Id)
        {
            return Delete(GetById(Id));
        }

        public T GetById(int Id)
        {
            return _objectSet.Find(Id);
        }

        public bool Insert(T entity)
        {
            _objectSet.Add(entity);
            return Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges()>0;
        }

        public bool Update(T entity)
        {
            _objectSet.AddOrUpdate(entity);
            return Save();
        }
    }
}
