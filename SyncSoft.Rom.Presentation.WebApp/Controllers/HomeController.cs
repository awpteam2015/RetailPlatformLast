using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommonFrameWork.Dependency;
using CommonFrameWork.Exception;
using CommonFrameWork.Logging;
using CommonFrameWork.ToolKit;
using CommonFrameWork.Web.Mvc.Models;
using SyncSoft.Rom.Application.ServiceContracts;


namespace SyncSoft.Rom.Presentation.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult ErrorTest()
        {
            ObjectContainer.Resolve<ILoggerFactory>().Create("RollingLogFileAppender").Debug("1111");
            return View();
        }


        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MeunList = ObjectContainer.Resolve<IPermissionService>().GetMenuList();
            ViewBag.UserInfo = UserInfo;
            return View();
        }

        public ContentResult Default()
        {

            return new ContentResult() {Content = ""};
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginOff()
        {
            FormsAuthentication.SignOut();
            CookieHelper.Del(FormsAuthentication.FormsCookieName); ;
            return MvcJsonResult.Success();
        }
    }
}