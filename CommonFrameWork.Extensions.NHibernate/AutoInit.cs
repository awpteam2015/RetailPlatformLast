using System;
using System.Collections.Generic;
using System.Linq;
using CommonFrameWork.Application;
using CommonFrameWork.Dependency;
using CommonFrameWork.Domain.Repositories;

namespace CommonFrameWork.Extensions.NHibernate
{
    internal class AutoInit : IAutoInitializer
    {
        public void Init(IEnumerable<System.Reflection.Assembly> assemblies)
        {
            //Type type = typeof(AutoInit);
            //var nowAssemblie = assemblies.FirstOrDefault(P => P.FullName.StartsWith(type.Assembly.FullName));
            //ObjectContainer.RegisterByAssembly(nowAssemblie);


            //  ObjectContainer.Register<IRepositoryContext, NHibernateContext>();

            ObjectContainer.Register<IRepositoryContext, NHibernateContext>(new List<ObjectContainerParameter>() {new ObjectContainerParameter()
            {
                Name = "sessionFactory",
               Value=new SessionFactoryProvider().GetSessionFactory()
            } });

            //ObjectContainer.Resolve<IRepositoryContext>(new ObjectContainerParameter()
            //{
            //    Name = "sessionFactory",
            //    Value = new SessionFactoryProvider().GetSessionFactory()
            //});

            // ObjectContainer.Register<IRepositoryContext, NHibernateContext>();

        }
    }
}
