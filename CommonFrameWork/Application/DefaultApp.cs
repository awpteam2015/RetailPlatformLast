using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.CommUtils;
using CommonFrameWork.Config;
using CommonFrameWork.DataMap;
using CommonFrameWork.Dependency;
using CommonFrameWork.Exception;
using CommonFrameWork.Logging;
using CommonFrameWork.Serialization;

namespace CommonFrameWork.Application
{
    /// <summary>
    /// 默认应用实例
    /// </summary>
    public class DefaultApp : IApp
    {
        private readonly IConfigSource _configSource;
        private static readonly object StopLocker = new object();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configSource"></param>
        public DefaultApp(IConfigSource configSource)
        {
            _configSource = configSource;


            //IOC容器
            if (configSource.Config.Application.ObjectContainer == null)
                throw new ConfigException("configSource.Config.Application.ObjectContainer  has not been defined");

            Type objectContainerType = Type.GetType(configSource.Config.Application.ObjectContainer);
            if (objectContainerType == null)
                throw new ConfigException("configSource.Config.Application.ObjectContainer defined by type {0} doesn't exist.", configSource.Config.Application.ObjectContainer);
            var objectContainer = (IObjectContainer)Activator.CreateInstance(objectContainerType);
            ObjectContainer.SetContainer(objectContainer);

            //log
            if (configSource.Config.Application.LogProvider != null)
            {
                Type logProvider = Type.GetType(configSource.Config.Application.LogProvider);
                if (logProvider == null)
                    throw new ConfigException("configSource.Config.Application.LogProvider defined by type {0} doesn't exist.", configSource.Config.Application.LogProvider);

                ObjectContainer.Register(typeof(ILoggerFactory),logProvider);
            }
            else
            {
                ObjectContainer.Register<ILoggerFactory, DefaultLoggerFactory>();
            }


            //序列化
            if (configSource.Config.Application.SerializationProvider != null)
            {
                Type serializationProvider = Type.GetType(configSource.Config.Application.SerializationProvider);
                if (serializationProvider == null)
                    throw new ConfigException("configSource.Config.Application.SerializationProvider defined by type {0} doesn't exist.", configSource.Config.Application.SerializationProvider);

                ObjectContainer.Register(typeof(IObjectSerializer), serializationProvider);
            }
            else
            {
                ObjectContainer.Register<IObjectSerializer, DefaultObjectSerializer>();
            }

            //数据拷贝
            if (configSource.Config.Application.DataMapProvider != null)
            {
                Type dataMapProviderType = Type.GetType(configSource.Config.Application.DataMapProvider);
                if (dataMapProviderType == null)
                    throw new ConfigException("configSource.Config.Application.DataMapProvider defined by type {0} doesn't exist.", configSource.Config.Application.DataMapProvider);
                var dataMapProvider = (IDataMapperProvider)Activator.CreateInstance(dataMapProviderType);
                DataMapper.SetProvider(dataMapProvider);
            }
        }



        #region Implementation of IApp

        public event ApplicationStartingEventHandler Starting;
        public event ApplicationStartedEventHandler Started;
        public event EventHandler Stopping;
        public void Start()
        {
            var assemblies = _configSource.Config.Application.Assemblies;

            if (null != Starting)
            {
                Starting(this, new ApplicationStartingEventArgs(assemblies));
            }

            AutoInit(assemblies);

            if (null != Started)
            {
                Started(this, new ApplicationStartedEventArgs(assemblies));
            }
        }

        public void Stop()
        {
            lock (StopLocker)
            {
                if (null != Stopping)
                {
                    Stopping(this, EventArgs.Empty);
                }
            }
        }

        #endregion


        #region
        private void AutoInit(IEnumerable<Assembly> assemblies)
        {
            var types = Utils.FindImplTypes<IAutoInitializer>(null, assemblies).ToList();

            Parallel.ForEach(types, (type) =>
            {
                ((IAutoInitializer)Activator.CreateInstance(type)).Init(assemblies);
            });
        }
        #endregion
    }



}
