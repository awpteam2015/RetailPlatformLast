using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager.Models
{
    public class FunctionRight
    {
 
        /// <summary>
        /// 操作ID
        /// </summary>
        public  string FunctionRightId { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public  string RightTag { get; set; }

        /// <summary>
        /// 操作对应页面控件Id
        /// </summary>
        public  string RightTagId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime? CreateDateTime { get; set; }

        ///<sumary>
        /// 功能ID
        ///</sumary>
        public  string FunctionId { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public  int OrderId { get; set; }

        ///<sumary>
        /// 功能对应的页面
        ///</sumary>
        public  string FunctinoRightUrl { get; set; }

        /// <summary>
        /// 功能
        /// </summary>
        public  ModuleFunction ModuleFunction { get; set; }

    }
}