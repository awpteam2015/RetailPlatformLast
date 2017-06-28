using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonFrameWork.CommUtils;
using CommonFrameWork.Web.Mvc.Models;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager.Controllers
{
    public class ModuleController : Controller
    {
        // GET: PermissionManager/Module
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hd()
        {
            return View();
        }


        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult List()
        {
            //var pIndex = RequestHelper.GetInt("page"); 
            // var pSize = RequestHelper.GetInt("rows");
            //var where = new ModuleEntity();
            ////where.PkId = RequestHelper.GetFormString("PkId");
            //where.ModuleName = RequestHelper.GetFormString("ModuleName");
            ////where.ParentId = RequestHelper.GetFormString("ParentId");
            ////where.ModuleLevel = RequestHelper.GetFormString("ModuleLevel");
            ////where.RankId = RequestHelper.GetFormString("RankId");
            ////where.Remark = RequestHelper.GetFormString("Remark");
            //var searchList = ModuleService.GetInstance().Search(where, (pIndex - 1) * pSize, pSize);

            //var dataGridEntity = new DataGridResponse()
            //{
            //    total = searchList.Item2,
            //    rows = searchList.Item1
            //};
            //return new AbpJsonResult(dataGridEntity, new NHibernateContractResolver());
            return View();
        }

    }
}