using System;
using System.Collections.Generic;
using System.Linq;

using CommonFrameWork.Application;
using CommonFrameWork.DataMap;
using CommonFrameWork.Dependency;
using SyncSoft.Rom.Application.Dto.PermissionManager;
using SyncSoft.Rom.Application.Implementation.OrderManager;
using SyncSoft.Rom.Application.Implementation.PermissionManager;
using SyncSoft.Rom.Application.ServiceContracts;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.Presentation.WebApp.Models;

namespace SyncSoft.Rom.Presentation.WebApp
{
    internal class AutoInit : IAutoInitializer
    {
        public void Init(IEnumerable<System.Reflection.Assembly> assemblies)
        {
            //Type type = typeof(AutoInit);
            //var nowAssemblie = assemblies.FirstOrDefault(P => P.FullName.StartsWith(type.Assembly.FullName));
            //ObjectContainer.RegisterByAssembly(nowAssemblie);

            //ObjectContainer.Register<IOrderService, OrderServiceImpl>();
            //ObjectContainer.Register<IPermissionService, PermissionServiceImpl>();
            ////ObjectContainer.Register<ICustomerDomainService, CustomerDomainService>();

             DataMapper.CreateMap(typeof(TestDto), typeof(TestVm));

        }




    }
}
