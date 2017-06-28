using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Config;
using CommonFrameWork.Exception;

namespace CommonFrameWork.Application
{
    /// <summary>
    /// 运行环境
    /// </summary>
    public sealed class AppRuntime
    {
        #region Private Static Fields

        private static readonly AppRuntime instance = new AppRuntime();
        private static readonly object lockObj = new object();
        private static  IConfigSource _configSource;
        #endregion Private Static Fields

        #region Private Fields

        private IApp currentApplication = null;

        #endregion Private Fields

        #region Ctor

        static AppRuntime()
        {
        }

        private AppRuntime()
        {
        }

        #endregion Ctor

        #region Public Static Properties

        /// <summary>
        /// Gets the instance of the current <c> ApplicationRuntime </c> class. 
        /// </summary>
        public static AppRuntime Instance
        {
            get { return instance; }
        }

        public static IConfigSource ConfigSource
        {
            get { return _configSource; }
        }

        #endregion Public Static Properties

        #region Public Properties

        /// <summary>
        /// Gets the instance of the currently running application. 
        /// </summary>
        public IApp CurrentApplication
        {
            get { return currentApplication; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// 创建应用环境
        /// </summary>
        /// <param name="configSource"></param>
        /// <returns></returns>
        public static IApp Create(IConfigSource configSource)
        {
            lock (lockObj)
            {
                if (instance.currentApplication == null)
                {
                    lock (lockObj)
                    {
                        if (configSource.Config == null ||
                            configSource.Config.Application == null)
                            throw new ConfigException("configSource.Config or  configSource.Config.Application  has not been defined");
                        string typeName = configSource.Config.Application.AppProvider;
                        if (string.IsNullOrEmpty(typeName))
                            throw new ConfigException("The provider type has not been defined .");
                        Type type = Type.GetType(typeName);
                        if (type == null)
                            throw new CommonFrameException("The application provider defined by type '{0}' doesn't exist.", typeName);
                        instance.currentApplication = (IApp)Activator.CreateInstance(type, new object[] { configSource });

                        _configSource = configSource;
                    }
                }
            }
            return instance.currentApplication;
        }


        #endregion Public Methods
    }
}
