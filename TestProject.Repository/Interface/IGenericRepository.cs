using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestProject.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
