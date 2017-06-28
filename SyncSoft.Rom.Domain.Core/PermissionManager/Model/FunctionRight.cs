using System;
using System.Collections.Generic;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    /// <summary>
    /// 功能页面对应操作
    /// </summary>
    public class FunctionRight : IAggregateRoot<string>
    {
        public virtual string PkId
        {
            get { return FunctionRightId; }
            set { FunctionRightId = value; }
        }
        /// <summary>
        /// 操作ID
        /// </summary>
        public virtual string FunctionRightId { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public virtual string RightTag { get; set; }

        /// <summary>
        /// 操作对应页面控件Id
        /// </summary>
        public virtual string RightTagId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateDateTime { get; set; }

        ///<sumary>
        /// 功能ID
        ///</sumary>
        public virtual string FunctionId { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public virtual int OrderId { get; set; }

        ///<sumary>
        /// 功能对应的页面
        ///</sumary>
        public virtual string FunctinoRightUrl { get; set; }

        /// <summary>
        /// 功能
        /// </summary>
        public virtual ModuleFunction ModuleFunction { get; set; }

        ///// <summary>
        ///// 角色权限
        ///// </summary>
        //public virtual ISet<RolePopedom> RolePopedoms { get; set; }

        ///// <summary>
        ///// 用户对应操作
        ///// </summary>
        //public virtual ISet<UserPopedom> UserPopedoms { get; set; }
    }
}
