using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager.Models
{
    public class ModuleFunction
    {
 
        ///<sumary>
        /// 功能ID
        ///</sumary>
        public string FunctionId { get; set; }

        ///<sumary>
        /// 功能名
        ///</sumary>
        public string FunctionName { get; set; }

        ///<sumary>
        /// 功能对应的页面
        ///</sumary>
        public string FunctionUrl { get; set; }

        ///<sumary>
        /// 功能说明
        ///</sumary>
        public string Remark { get; set; }

        ///<sumary>
        /// 是否禁用
        ///</sumary>
        public int? Disabled { get; set; }

        ///<sumary>
        /// 排序号
        ///</sumary>
        public int? OrderId { get; set; }

        ///<sumary>
        /// 模组ID
        ///</sumary>
        public string ModuleId { get; set; }

        ///<sumary>
        /// 所属模组
        ///</sumary>
        public Module Module { get; set; }
         
        /// <summary>
        /// 功能对应那些操作
        /// </summary>
        public ISet<FunctionRight> FunctionRights { get; set; }
    }
}