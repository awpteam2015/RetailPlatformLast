using System;
using System.Collections.Generic;
using System.Linq;
using CommonFrameWork.Application;
using CommonFrameWork.Dependency;
using SyncSoft.Rom.Domain.Core.CustomerManager.Services;
using SyncSoft.Rom.Domain.Core.OrderManager.Services;

namespace SyncSoft.Rom.Domain.Core
{
    internal class AutoInit : IAutoInitializer
    {
        public void Init(IEnumerable<System.Reflection.Assembly> assemblies)
        {
            Type type = typeof(AutoInit);
            var nowAssemblie = assemblies.FirstOrDefault(P => P.FullName.StartsWith(type.Assembly.FullName));
            ObjectContainer.RegisterByAssembly(nowAssemblie, "","Service");

          //  ObjectContainer.Register<IOrderDomainService, OrderDomainService>();
            //ObjectContainer.Register<ICustomerDomainService, CustomerDomainService>();


        }
    }
}
