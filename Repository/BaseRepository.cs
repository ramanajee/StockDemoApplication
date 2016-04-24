using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockDemo.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        IList<T> db;
        public BaseRepository(IList<T> data)
        {
            db = data;
        }
        public bool Add(T entity)
        {
            db.Add(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            db.Remove(entity);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool v)
        {
            if (v)
            {
                // TODO :  _____
            }
        }
           
        public IList<T> Get(Expression<Func<T, bool>> filter)
        {
            return db.AsQueryable().Where(filter).ToList();
        }

        public IList<T> GetAll()
        {
            return db;
        }
    }
}
