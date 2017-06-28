using SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /PermissionManager/User/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User _user)
        {
            if(ModelState.IsValid)
            { 
                 
                     
            }
            else
            {
                
            }
            return View();
        }
	}
}