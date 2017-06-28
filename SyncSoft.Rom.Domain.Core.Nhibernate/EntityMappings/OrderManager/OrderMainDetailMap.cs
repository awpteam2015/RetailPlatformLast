using FluentNHibernate.Mapping;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.OrderManager
{
    public  class OrderMainDetailMap : ClassMap<OrderMainDetail>
    {
        protected OrderMainDetailMap()
        {
            Table("TEST_ORDERMAINDETAIL");
            Id(p => p.PkId).GeneratedBy.Sequence("SEQ_TEST_ORDERMAINDETAIL"); ;
            Map(p => p.OrderNo);
            Map(p => p.ProductName);

        }

    }
}
