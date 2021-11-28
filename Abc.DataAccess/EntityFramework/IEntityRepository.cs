using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Abc.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T : class, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
