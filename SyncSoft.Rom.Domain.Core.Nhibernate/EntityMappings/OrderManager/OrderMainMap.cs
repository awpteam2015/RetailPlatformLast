using FluentNHibernate.Mapping;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.OrderManager
{
    public  class OrderMainMap : ClassMap<OrderMain>
    {
        protected OrderMainMap()
        {
            Table("TEST_ORDERMAIN");
            Id(p => p.PkId);
           // Id(p => p.ID).GeneratedBy.Sequence("SEQ_TEST_ORDERMAIN"); ;
            Map(p => p.CustomerId);

            HasMany(p => p.OrderMainDetailList)
                .AsSet().Generic()
                .Inverse()
                .LazyLoad().Cascade.All().KeyColumn("OrderNo");
      

        }

    }
}
