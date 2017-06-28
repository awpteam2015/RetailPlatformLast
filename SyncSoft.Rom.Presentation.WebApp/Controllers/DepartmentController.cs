using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFrameWork.DataMap;
using CommonFrameWork.Dependency;
using SyncSoft.Rom.Application.Dto.PermissionManager;
using SyncSoft.Rom.Application.ServiceContracts;
using SyncSoft.Rom.Presentation.WebApp.Models;

namespace SyncSoft.Rom.Presentation.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {

        var t=    ObjectContainer.Resolve<IPermissionService>().Test(new LoginDto());

            try
            {
                var vm = DataMapper.Map<TestVm>(t);
            }
            catch (Exception e)
            {
                
                throw;
            }
            

            return View();
        }
    }
}