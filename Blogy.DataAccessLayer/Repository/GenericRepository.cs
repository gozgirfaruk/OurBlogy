using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly BlogyContext _context;
        void IGenericDal<T>.Delete(T entity)
        {
            var values = _context.Set<T>().Find(entity);
            _context.Set<T>().Remove(values);
        }

        List<T> IGenericDal<T>.GetAll()
        {
            return _context.Set<T>().ToList();
        }

        T IGenericDal<T>.GetyById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        void IGenericDal<T>.Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        void IGenericDal<T>.Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
