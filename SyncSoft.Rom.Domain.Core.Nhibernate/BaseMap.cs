using FluentNHibernate.Mapping;

namespace SyncSoft.Rom.Domain.Core.Nhibernate
{
    /// <summary>
    /// 表的映射基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseMap<T> : ClassMap<T> where T : class 
    {
        protected BaseMap()
        {
            DynamicInsert();
            DynamicUpdate();
        }
    }

    /// <summary>
    /// 带OMS.前缀
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OmsBaseMap<T> : BaseMap<T> where T : class
    {
        protected OmsBaseMap()
        {
            Schema("OMS");
        }
    }


    /// <summary>
    /// 视图的映射基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewBaseMap<T> : ClassMap<T> where T : class
    {
        protected ViewBaseMap()
        {
            ReadOnly();
        }
    }

    /// <summary>
    /// 带OMS.前缀
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OmsViewBaseMap<T> : ViewBaseMap<T> where T : class
    {
        protected OmsViewBaseMap()
        {
            Schema("OMS");
        }
    }



}
