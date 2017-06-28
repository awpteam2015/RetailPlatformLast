using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Extensions.NHibernate.EntityMappings;
using FluentNHibernate.Mapping;
using Project.Domain.Core.OrderManager.PersistentObject;

namespace Project.Domain.Core.Nhibernate.EntityMappings.OrderManager
{
    public  class OrderMainMap2 : ClassMap<OrderMain2>
    {
        protected OrderMainMap2()
        {

            Table("TEST_ORDERMAIN2");
            Id(p => p.ID);
            Map(p => p.OrderNo);
          

        }

    }
}
