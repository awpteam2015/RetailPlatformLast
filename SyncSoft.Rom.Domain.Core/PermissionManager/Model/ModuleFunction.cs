using System.Collections.Generic;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    /// <summary>
    /// 模块对应功能
    /// </summary>
    public class ModuleFunction : IAggregateRoot<string>
    {
        public virtual string PkId
        {
            get { return FunctionId; }
            set { FunctionId = value; }
        }

        ///<sumary>
        /// 功能ID
        ///</sumary>
        public virtual string FunctionId { get; set; }

        ///<sumary>
        /// 功能名
        ///</sumary>
        public virtual string FunctionName { get; set; }

        ///<sumary>
        /// 功能对应的页面
        ///</sumary>
        public virtual string FunctionUrl { get; set; }

        ///<sumary>
        /// 功能说明
        ///</sumary>
        public virtual string Remark { get; set; }

        ///<sumary>
        /// 是否禁用
        ///</sumary>
        public virtual int? Disabled { get; set; }

        ///<sumary>
        /// 排序号
        ///</sumary>
        public virtual int? OrderId { get; set; }

        ///<sumary>
        /// 模组ID
        ///</sumary>
        public virtual string ModuleId { get; set; }

        ///<sumary>
        /// 所属模组
        ///</sumary>
        public virtual Module Module { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string FunctionUrl2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Area { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Controller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Action { get; set; }

        /// <summary>
        /// 功能对应那些操作
        /// </summary>
        public virtual ISet<FunctionRight> FunctionRights { get; set; }
    }
}
