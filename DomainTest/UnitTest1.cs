using System;
using System.Collections.Generic;
using System.Reflection;
using CommonFrameWork.Application;
using CommonFrameWork.CommUtils;
using CommonFrameWork.Config;
using CommonFrameWork.DataMap;
using CommonFrameWork.Dependency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyncSoft.Rom.Domain.Core.TestManager.Repositories;
using SyncSoft.Rom.Domain.Core.TestManager.Services;

namespace DomainTest
{
    [TestClass]
    public class UnitTest1
    {


        private void AppInit()
        {
            IConfigSource configSource = new DefaultConfig();
            configSource.Config.Application.AppProvider = "CommonFrameWork.Application.DefaultApp,CommonFrameWork";
            configSource.Config.Application.ObjectContainer = "CommonFrameWork.Extensions.Autofac.AutofacObjectContainer,CommonFrameWork.Extensions.Autofac";
            configSource.Config.Application.SerializationProvider = "CommonFrameWork.Extensions.NewTonSoft.NewTonSoftSerializer,CommonFrameWork.Extensions.NewTonSoft";
            configSource.Config.Application.DataMapProvider = "CommonFrameWork.Extensions.AutoMapper.DataMapperProvider,CommonFrameWork.Extensions.AutoMapper";

            var list = new List<Assembly>();
            list.AddRange(Utils.GetAllAssemblies("SyncSoft.Rom.Domain.Core.Nhibernate"));
            list.AddRange(Utils.GetAllAssemblies("SyncSoft.Rom.Domain.Core"));
            list.AddRange(Utils.GetAllAssemblies("CommonFrameWork.Extensions.NHibernate"));
            //list.AddRange(Utils.GetAllAssemblies("SyncSoft.Rom.Domain.Events.Handlers"));
            list.AddRange(Utils.GetAllAssemblies("SyncSoft.Rom.Application"));
            list.AddRange(Utils.GetAllAssemblies("SyncSoft.Rom.Presentation.WebApp"));
            configSource.Config.Application.Assemblies = list;
            configSource.Config.Application.LogProvider = "CommonFrameWork.Extensions.Log4Net.Log4NetLoggerFactory,CommonFrameWork.Extensions.Log4Net";

            var application = AppRuntime.Create(configSource)
                .ConfigMessageDispatcher();
            application.Start();

            ObjectContainer.Build();
            DataMapper.Init();
        }

        public UnitTest1()
        {
            AppInit();
        }

        [TestMethod]
        public void TestMethod1()
        {
            ObjectContainer.Resolve<ITableService>().Add();


        }


        [TestMethod]
        public void TestMethod2()
        {
            ObjectContainer.Resolve<ITableService>().TransactionTest();
        }


        [TestMethod]
        public void TestMethod3()
        {
            ObjectContainer.Resolve<ITableService>().MunThread();
        }

        [TestMethod]
        public void TestMethod4()
        {
            ObjectContainer.Resolve<ITableService>().Del();
        }

        [TestMethod]
        public void TestMethod7()
        {
            ObjectContainer.Resolve<ITableService>().GetList();



        }

    }
}
