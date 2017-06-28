using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Config
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonFrameWorkConfig
    {
        public CommonFrameWorkConfig()
        {
            Application = new Application();
        }


        public Application Application { get; set; }


    }

    public class Application
    {
        public Application()
        {
            DistributedConfig=new DistributedConfig();
        }

        /// <summary>
        ///应用实现  存在默认实现
        /// </summary>
        public string AppProvider { get; set; }

        /// <summary>
        ///日志实现  存在默认实现
        /// </summary>
        public string LogProvider { get; set; }

        /// <summary>
        ///序列化实现 存在默认实现
        /// </summary>
        public string SerializationProvider { get; set; }

        /// <summary>
        /// 数据拷贝实现
        /// </summary>
        public string DataMapProvider { get; set; }

        /// <summary>
        ///容器实现 目前没有实现默认实现必须指定
        /// </summary>
        public string ObjectContainer { get; set; }

        /// <summary>
        /// 需要加载的程序集
        /// </summary>
        public IList<Assembly> Assemblies { get; set; }

        /// <summary>
        /// 分布式配置
        /// </summary>
        public DistributedConfig DistributedConfig { get; set; }


    }
}
