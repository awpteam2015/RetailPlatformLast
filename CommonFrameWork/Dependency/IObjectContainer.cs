using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Dependency
{
    public interface IObjectContainer
    {
        void Build();

        object InnerContainer { get; }
        object Resolve(Type serviceType);
        TService Resolve<TService>() where TService : class;


        void Register<TService>(Func<TService> instanceCreator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType">服务接口</param>
        /// <param name="implType">实现</param>
        void Register(Type serviceType, Type implType);

        /// <summary>
        /// 带参数注册
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implType"></param>
        /// <param name="parameters"></param>
        void Register(Type serviceType, Type implType, List<ObjectContainerParameter> parameters);

        /// <summary>
        /// 通过程序集注册 默认注册成接口服务
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix">后缀</param>
        void Register(Assembly assembly, string prefix, string suffix);

        /// <summary>
        /// 通过程序集注册 默认注册成接口服务
        /// </summary>
        /// <param name="assembly"></param>
        void Register(Assembly assembly);

        /// <summary>
        /// 实现
        /// </summary>
        /// <param name="serviceType"></param>
        void Register(Type serviceType);

        /// <summary>
        /// 注册泛型
        /// </summary>
        /// <param name="serviceType"></param>
        void RegisterGeneric(Type serviceType, Type implType);

        void Register<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        /// <summary>
        /// 带参数注册
        /// </summary>
        /// <param name="parameters"></param>
        void Register<TService, TImplementation>(List<ObjectContainerParameter> parameters)
            where TService : class
            where TImplementation : class, TService;



        TService Resolve<TService>(List<ObjectContainerParameter> parameters)
            where TService : class;


        object Resolve(Type serviceType, List<ObjectContainerParameter> parameters);

        IEnumerable<ComponentRegistration> GetRegistrations();

    }
}
