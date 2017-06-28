using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommonFrameWork.Application;
using CommonFrameWork.Dependency;
using CommonFrameWork.ToolKit;
using CommonFrameWork.Web.Mvc.Models;
using Newtonsoft.Json;
using SyncSoft.Rom.Application.Dto.PermissionManager;
using SyncSoft.Rom.Application.ServiceContracts;
using SyncSoft.Rom.Domain.Core.PermissionManager.Services;
using SyncSoft.Rom.Presentation.WebApp.Models;

namespace SyncSoft.Rom.Presentation.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserLogin(LoginVm vm)
        {
            var result = ObjectContainer.Resolve<IPermissionService>().Login(new LoginDto()
            {
                LoginId = vm.LoginId,
                Password = Encrypt.MD5Encrypt(vm.Password),
                SelectDepartmentCode=vm.SelectDepartmentCode
            });

            var ticket = new FormsAuthenticationTicket(
            1 /*version*/,
            Guid.NewGuid().ToString(),
            DateTime.Now,
            DateTime.Now.AddMinutes(300),
            true,//持久性
            JsonConvert.SerializeObject(result.Data),
            FormsAuthentication.FormsCookiePath);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.Expires = DateTime.Now.AddMinutes(300);
            cookie.HttpOnly = true;
            //cookie.Domain = "SyncSoft.Rom.Presentation.WebApp_Test";
            Response.Cookies.Add(cookie);

            return MvcJsonResult.Result(result);
        }


        [HttpPost]
        public JsonResult ChangeLoginName(string loginId)
        {
            var result = ObjectContainer.Resolve<IPermissionDomainService>().GetDepartmentList(loginId);
            return MvcJsonResult.Result(result);
        }



    }
}