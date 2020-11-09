using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TestProject.Model;
using TestProject.Repository.Interface;

namespace TestProject.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DatabaseContext _dbContext = null;
        private DbSet<T> _table = null;

        public GenericRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }
        
        public void Add(T entity)
        {
            _table.Add(entity);
        }


        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }
            else
            {
                T _entity = entity;

                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                Update(_entity);
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate);
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }
    }
}
