using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Models
{
    public class RolePopedom
    {
        public override string Id
        {
            get { return string.Format("{0}-{1}-{2}", RoleId, FunctionRightId, PopedomValue); }
        }

        /// <summary>
        /// 角色Id
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 功能操作Id
        /// </summary>
        public virtual string FunctionRightId { get; set; }

        /// <summary>
        /// -1代表禁用操作，1代表可用操作
        /// </summary>
        public virtual int PopedomValue { get; set; }

        ///<sumary>
        /// 角色
        ///</sumary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// 功能操作
        /// </summary>
        public virtual FunctionRight FunctionRight { get; set; }
    }
}