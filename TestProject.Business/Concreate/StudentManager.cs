using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestProject.Business.Abstract;
using TestProject.Business.ValidationRules.FluentValidation;
using TestProject.Core.Aspects.Autofac.Validation;
using TestProject.Core.Validation.FluentValidation;
using TestProject.Entity.Entity;
using TestProject.Repository.Interface;

namespace TestProject.Business.Concreate
{
    public class StudentManager : IStudentService
    {
        public readonly IGenericRepository<Student> _student;

        public StudentManager(IGenericRepository<Student> student)
        {
            _student = student;
        }

        [ValidationInterceptionAspect(typeof(StudentValidaton))]
        public void Add(Student entity)
        {
            //AOP
            //ValidationTool.Validate(new StudentValidaton(), entity);

            _student.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student Get(Expression<Func<Student, bool>> predicate)
        {
            return _student.Get(predicate);
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
