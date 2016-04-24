using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockDemo.Repository
{
    interface IBaseRepository<T>: IDisposable where T: class 
    {
        IList<T> Get(Expression<Func<T, bool>> filter);
        IList<T> GetAll();
        bool Add(T entity);
        bool Delete(T entity);
    }
}
