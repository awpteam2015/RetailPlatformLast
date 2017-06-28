using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Models
{
    public class Role
    {
        public override string Id
        {
            get { return RoleId; }
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 角色名字
        /// </summary>
        public virtual string RoleName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 角色所属的用户
        /// </summary>
        public virtual ISet<User> Users { get; set; }

        /// <summary>
        /// 角色权限
        /// </summary>
        public virtual ISet<RolePopedom> RolePopedoms { get; set; }
        ///<sumary>
        /// 排序号
        ///</sumary>
        public virtual int? OrderId { get; set; }
    }
}