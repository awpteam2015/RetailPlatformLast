using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CommonFrameWork.Dependency;
using CommonFrameWork.Exception;
using CommonFrameWork.Extensions.NHibernate;
using CommonFrameWork.Logging;
using CommonFrameWork.Web.Mvc.Models;
using SyncSoft.Rom.Application.ServiceContracts;

namespace SyncSoft.Rom.Presentation.WebApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxErrorTest()
        {
            throw new CommonFrameException("xxxxxxxx");
            return View();
        }


        public ActionResult ErrorTest()
        {
            throw new CommonFrameException("xxxxxxxx");
            return View();
        }


        [HttpPost]
        public MvcJsonResult Add()
        {
            var t = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                t.Add(i);
            }

            ObjectContainer.Resolve<IOrderService>().Add();

            //Parallel.ForEach(t, new ParallelOptions { MaxDegreeOfParallelism = 10 }, item =>
            //{
            //    ObjectContainer.Resolve<IOrderService>().Add();
            //});

            // ObjectContainer.Resolve<IOrderDomainService>().Add();

            return new MvcJsonResult("111111");
        }


        /// <summary>
        /// 不用ioc单独执行不会有内存不释放的问题
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ContentResult Add3()
        {
            // var ordermain = new OrderMain() { ID = Guid.NewGuid().ToString(), CustomerId = "2222" };
            //// var context = new NHibernateContext();
            // var res=  new OrderMainRepository(context);
            // res.Add(ordermain);
            // res.context.Commit();
            // res.context.Dispose();

            //var service=
            //ObjectContainer.Resolve<IOrderDomainService>().Add();

            ObjectContainer.Resolve<IOrderService>().Add();

            return Content("");
        }


        /// <summary>
        /// 不用ioc单独执行不会有内存不释放的问题
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ContentResult Add4()
        {
            try
            {
                ObjectContainer.Resolve<IOrderService>().Add();
            }
            catch (Exception e)
            {
                throw;
            }
        
            //var ordermain = new OrderMain() { ID = Guid.NewGuid().ToString(), CustomerId = "2222" };
            ////var context = new NHibernateContext();
            //var res = ObjectContainer.Resolve<IOrderMainRepository>();
            //res.Add(ordermain);
            //res.Context.Commit();
            //res.Context.Dispose();

            //var service=
            //ObjectContainer.Resolve<IOrderDomainService>().Add();

            return Content("");
        }


        [HttpGet]
        public ContentResult delete2222()
        {
            try
            {
                ObjectContainer.Resolve<IOrderService>().delete();
            }
            catch (Exception e)
            {
                throw;
            }

            //var ordermain = new OrderMain() { ID = Guid.NewGuid().ToString(), CustomerId = "2222" };
            ////var context = new NHibernateContext();
            //var res = ObjectContainer.Resolve<IOrderMainRepository>();
            //res.Add(ordermain);
            //res.Context.Commit();
            //res.Context.Dispose();

            //var service=
            //ObjectContainer.Resolve<IOrderDomainService>().Add();

            return Content("");
        }



        [HttpGet]
        public ContentResult Add2()
        {
            //ObjectContainer.Resolve<IOrderService>().Add();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var t = new List<int>();
                for (int i = 0; i < 500; i++)
                {
                    t.Add(i);
                }

                Parallel.ForEach(t, new ParallelOptions { MaxDegreeOfParallelism = 30 }, item =>
                {
                    ObjectContainer.Resolve<IOrderService>().Add();
                });

                //t.ForEach(p =>
                //{
                //    ObjectContainer.Resolve<IOrderService>().Add();
                //});

                //  Task.Run(() =>
                //  {
                //      Parallel.ForEach(t, item =>
                //{
                //    ObjectContainer.Resolve<IOrderService>().Add();
                //});
                //  });

                //Parallel.ForEach(t, item =>
                //{
                //    var txxx = "xxxx";
                //});
            }
            catch (Exception e)
            {
                ObjectContainer.Resolve<ILoggerFactory>().Create("RollingLogFileAppender").Debug(e);
                throw;
            }
            stopwatch.Stop();
            // ObjectContainer.Resolve<IOrderDomainService>().Add();
            return Content(stopwatch.Elapsed.ToString());
        }



        /// <summary>
        /// 测试context dispose的情况
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ContentResult Add5()
        {
            //ObjectContainer.Resolve<IOrderDomainService>().Test();

            return Content("");
        }


        [HttpPost]
        public MvcJsonResult Delete()
        {
            //  ObjectContainer.Resolve<IOrderDomainService>().Delete();

            return new MvcJsonResult("111111");
        }


        [HttpPost]
        public MvcJsonResult Update()
        {
            //ObjectContainer.Resolve<IOrderDomainService>().Update();

            return new MvcJsonResult("111111");
        }



        [HttpPost]
        public MvcJsonResult Get()
        {
            // var entity = ObjectContainer.Resolve<IOrderDomainService>().Get();

            return new MvcJsonResult(null);
        }


        [HttpPost]
        public MvcJsonResult TriggerOtherDomain()
        {
            // ObjectContainer.Resolve<IOrderDomainService>().TriggerOtherDomain();

            return new MvcJsonResult("TriggerOtherDomain");
        }





    //'9200031074',
    //'9200031513',
    //'9200031523',
    //'9200034104',
    //'9200034802',
    //'9200026303',
    //'9200031543',
    //'9200034923',
    //'9200030524',
    //'9200030578',
    //'9200033763',
    //'9200029998',
    //'9200031888',
    //'9200033051',
    //'9200034209',
    //'9200030884',
    //'9200029336',
    //'9200032502',
    //'9200034681',
    //'9200031249',
    //'9200033218',
    //'9200026256',
    //'9200033304',
    //'9200034198',




    }
}