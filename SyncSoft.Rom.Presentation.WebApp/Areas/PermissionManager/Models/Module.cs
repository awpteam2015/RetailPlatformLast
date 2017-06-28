using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager.Models
{
    public class Module
    {
   
        ///<sumary>
        /// 模组ID
        ///</sumary>
        public string ModuleId { get; set; }

        ///<sumary>
        /// 父模组ID
        ///</sumary>
        public string ParentId { get; set; }

        ///<sumary>
        /// 模组级别
        ///</sumary>
        public int? ModuleLevel { get; set; }

        ///<sumary>
        /// 模组名
        ///</sumary>
        public string ModuleName { get; set; }

        ///<sumary>
        /// 模组说明
        ///</sumary>
        public string Remark { get; set; }

        ///<sumary>
        /// 模组排序号
        ///</sumary>
        public virtual int? OrderId { get; set; }



        /// <summary>
        /// 所有的子模块
        /// </summary>
        public ISet<ModuleFunction> ModuleFunctions { get; set; }
    }
}