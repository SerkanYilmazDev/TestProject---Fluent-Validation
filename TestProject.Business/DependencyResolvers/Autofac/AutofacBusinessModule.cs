using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Business.Abstract;
using TestProject.Business.Concreate;
using TestProject.Core.Utilities.Interceptors;
using TestProject.Entity.Entity;
using TestProject.Repository.Interface;
using TestProject.Repository.Repository;

namespace TestProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentManager>().As<IStudentService>().SingleInstance();
            builder.RegisterType<GenericRepository<Student>>().As<IGenericRepository<Student>>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
              .AsImplementedInterfaces()
              .EnableInterfaceInterceptors(new ProxyGenerationOptions()
              {
                  Selector = new AspectInterceptorSelector()
              })
              .SingleInstance();
        }
    }
}
