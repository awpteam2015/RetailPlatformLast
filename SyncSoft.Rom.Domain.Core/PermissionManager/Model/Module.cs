using System.Collections.Generic;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    /// <summary>
    /// 模块组
    /// </summary>
    public class Module : IAggregateRoot<string>
    {
        public virtual string PkId
        {
            get { return ModuleId; }
            set { ModuleId = value; }
        }

        ///<sumary>
        /// 模组ID
        ///</sumary>
        public virtual string ModuleId { get; set; }

        ///<sumary>
        /// 父模组ID
        ///</sumary>
        public virtual string ParentId { get; set; }

        ///<sumary>
        /// 模组级别
        ///</sumary>
        public virtual int? ModuleLevel { get; set; }

        ///<sumary>
        /// 模组名
        ///</sumary>
        public virtual string ModuleName { get; set; }

        ///<sumary>
        /// 模组说明
        ///</sumary>
        public virtual string Remark { get; set; }

        ///<sumary>
        /// 模组排序号
        ///</sumary>
        public virtual int? OrderId { get; set; }



        /// <summary>
        /// 所有的子模块
        /// </summary>
        public virtual ISet<ModuleFunction> ModuleFunctions { get; set; }
    }
}
