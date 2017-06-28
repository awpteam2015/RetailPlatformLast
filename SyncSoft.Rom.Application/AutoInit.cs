using System;
using System.Collections.Generic;
using System.Linq;
using CommonFrameWork.Application;
using CommonFrameWork.DataMap;
using CommonFrameWork.Dependency;
using SyncSoft.Rom.Application.Dto.PermissionManager;
using SyncSoft.Rom.Application.Implementation;
using SyncSoft.Rom.Application.Implementation.OrderManager;
using SyncSoft.Rom.Application.Implementation.PermissionManager;
using SyncSoft.Rom.Application.ServiceContracts;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;

namespace SyncSoft.Rom.Application
{
    internal class AutoInit : IAutoInitializer
    {
        public void Init(IEnumerable<System.Reflection.Assembly> assemblies)
        {
            #region service

            Type type = typeof(AutoInit);
            var nowAssemblie = assemblies.FirstOrDefault(P => P.FullName.StartsWith(type.Assembly.FullName));
            ObjectContainer.RegisterByAssembly(nowAssemblie,"", "ServiceImpl");
          //  ObjectContainer.Register<IOrderService, OrderServiceImpl>();
          //  ObjectContainer.Register<IPermissionService, PermissionServiceImpl>();
            //ObjectContainer.Register<ICustomerDomainService, CustomerDomainService>();

            #endregion

            #region automapper

            DataMapper.CreateMap(typeof(TestDo), typeof(TestDto));

            DataMapper.CreateMap(typeof(User), typeof(UserInfoDto));

            #endregion


        }



    }
}
