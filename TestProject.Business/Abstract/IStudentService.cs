using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestProject.Entity.Entity;

namespace TestProject.Business.Abstract
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetAll(Expression<Func<Student, bool>> predicate);
        Student GetById(int id);
        Student Get(Expression<Func<Student, bool>> predicate);
        void Add(Student entity);
        void Delete(int id);
        void Update(Student entity);
    }
}
