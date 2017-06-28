using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using CommonFrameWork.Dependency;
using ComponentRegistration = CommonFrameWork.Dependency.ComponentRegistration;

namespace CommonFrameWork.Extensions.Autofac
{
    /// <summary>
    /// 
    /// </summary>
    internal class AutofacObjectContainer : IObjectContainer
    {
      //  private   IContainer _IContainer;

        #region -  Property(ies)  -

        public void Build()
        {
            Holder.Container = Holder.ContainerBuilder.Build();
        }

        public object InnerContainer
        {
            get { return Holder.ContainerBuilder; }
        }
        #endregion

        #region -  Register  -

        public void Register<TService>(Func<TService> instanceCreator)
        {
            Holder.ContainerBuilder.Register<TService>(c => instanceCreator());
        }

        public void Register(Type serviceType, Type implType)
        {
            Holder.ContainerBuilder.RegisterType(implType).As(serviceType);
        }


        public void Register(Type serviceType, Type implType, List<ObjectContainerParameter> parameters)
        {
            var autofacparametersList = new List<NamedParameter>();
            parameters.ForEach(p =>
            {
                autofacparametersList.Add(new NamedParameter(p.Name, p.Value));
            });

            Holder.ContainerBuilder.RegisterType(implType).As(serviceType).WithParameters(autofacparametersList);
        }


        public void Register(Assembly assembly)
        {
            Holder.ContainerBuilder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
        }


        public void Register(Assembly assembly, string prefix, string suffix)
        {
            if (!string.IsNullOrWhiteSpace(prefix))
            {
                var list = Holder.ContainerBuilder.RegisterAssemblyTypes(assembly)
                      .Where(p => p.Name.StartsWith(prefix));

                Holder.ContainerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(p => p.Name.StartsWith(prefix))
                    .AsImplementedInterfaces();
            }

            if (!string.IsNullOrWhiteSpace(suffix))
            {

                var list = Holder.ContainerBuilder.RegisterAssemblyTypes(assembly).Where(p => p.Name.EndsWith(suffix));

                Holder.ContainerBuilder.RegisterAssemblyTypes(assembly).Where(p => p.Name.EndsWith(suffix)).AsImplementedInterfaces();
            }

        }


        public void RegisterGeneric(Type serviceType, Type implType)
        {
            Holder.ContainerBuilder.RegisterGeneric(implType).As(serviceType);

        }

        public void Register(Type serviceType)
        {
            Holder.ContainerBuilder.RegisterType(serviceType);
        }

        public void Register<TService, TImplementation>(List<ObjectContainerParameter> parameters)
            where TService : class
            where TImplementation : class, TService
        {
            var autofacparametersList = new List<NamedParameter>();
            parameters.ForEach(p =>
            {
                autofacparametersList.Add(new NamedParameter(p.Name, p.Value));
            });

            Holder.ContainerBuilder.RegisterType<TImplementation>().As<TService>().WithParameters(autofacparametersList);
        }


        public void Register<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            Holder.ContainerBuilder.RegisterType<TImplementation>().As<TService>();
        }
        #endregion

        #region -  Resolve  -

        public TService Resolve<TService>() where TService : class
        {
#if DEBUG

            var registerlist = Holder.Container
                    .ComponentRegistry.Registrations.ToList()
                    .Select(p => p.Activator.LimitType.AssemblyQualifiedName)
                    .ToList();
#endif

            return Holder.Container.Resolve<TService>();
        }

        public object Resolve(Type serviceType)
        {
            return Holder.Container.Resolve(serviceType);
        }


        public TService Resolve<TService>(List<ObjectContainerParameter> parameters)
           where TService : class
        {
            var autofacparametersList = new List<NamedParameter>();
            parameters.ForEach(p =>
            {
                autofacparametersList.Add(new NamedParameter(p.Name, p.Value));
            });

            return Holder.Container.Resolve<TService>(autofacparametersList);
        }


        public object Resolve(Type serviceType, List<ObjectContainerParameter> parameters)
        {
            var autofacparametersList = new List<NamedParameter>();
            parameters.ForEach(p =>
            {
                autofacparametersList.Add(new NamedParameter(p.Name, p.Value));
            });
            return Holder.Container.Resolve(serviceType, autofacparametersList);
        }


        public IEnumerable<ComponentRegistration> GetRegistrations()
        {
            var returnList = new List<ComponentRegistration>();
            var list = Holder.Container.ComponentRegistry.Registrations;

            list.ToList().ForEach(p =>
            {
                var firstOrDefault = p.Services.FirstOrDefault();
                if (firstOrDefault != null)
                {

                    Type logProvider = Type.GetType(firstOrDefault.Description);
                }

                returnList.Add(new ComponentRegistration(p.Activator.LimitType));
            });

            return returnList;
        }

        #endregion



    }
}