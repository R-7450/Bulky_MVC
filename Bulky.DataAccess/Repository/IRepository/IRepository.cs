using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
   public interface IRepository<T> where T : class
    {
        //T - category , now we will define all the method that will need for category 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);// this method will get any particular category using id;
        void Add(T entity);
       
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
