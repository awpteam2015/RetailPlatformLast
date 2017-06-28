using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using CommonFrameWork.Application;
using CommonFrameWork.CommUtils;
using CommonFrameWork.Config;
using CommonFrameWork.DataMap;
using CommonFrameWork.Dependency;

namespace SyncSoft.Rom.Presentation.WebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AppInit();
        }


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


    }
}