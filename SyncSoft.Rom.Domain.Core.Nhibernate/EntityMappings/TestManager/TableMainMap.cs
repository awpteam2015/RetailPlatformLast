using FluentNHibernate.Mapping;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;
using SyncSoft.Rom.Domain.Core.TestManager.Model;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.TestManager
{
    public class TableMainMap : ClassMap<TableMain>
    {
        protected TableMainMap()
        {
            Table("TEST_TABLEMAIN");
            Id(p => p.PkId).GeneratedBy.Sequence("SEQ_TEST_TABLEMAIN");
            Map(p => p.AAName);
        }

    }
}
