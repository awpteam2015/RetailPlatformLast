using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentNHibernate.Cfg;
using NHibernate;

namespace CommonFrameWork.Extensions.NHibernate
{
    /// <summary>
    /// 这里有个问题这些类本来不应该写在这 应该写在对应项目下 不应该写在底层框架中
    /// </summary>
    public class SessionFactoryProvider : ISessionFactoryProvider
    {
      

        public static ISessionFactory SessionFactory;

        #region Implementation of ISessionFactoryProvider

        public  ISessionFactory GetSessionFactory()
        {

          
                HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
                var path = "";
                if (HttpContext.Current != null)
                {
                    path = HttpContext.Current.Server.MapPath("/Config/hibernate.cfg.xml");
                }
                else
                {
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Config\",
                         "hibernate.cfg.xml");
                }

                var config = new global::NHibernate.Cfg.Configuration().Configure(path);
                var t = Fluently.Configure(config);
                try
                {
                    var mapAssembly = Assembly.Load("SyncSoft.Rom.Domain.Core.Nhibernate");
                    var sessionFactory = Fluently.Configure(config)
                        .Mappings(m => m.FluentMappings.AddFromAssembly(mapAssembly)
                        //.ExportTo(@"E:\XmlMappings2")
                        ).BuildSessionFactory();

                    return sessionFactory;
                }
                catch (System.Exception e)
                {
                    throw e;
                }
      
        }

        #endregion
    }
}
