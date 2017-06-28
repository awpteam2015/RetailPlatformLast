using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    public class Role : IAggregateRoot<String>
    {
        #region Implementation of IEntity<string>

        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>
        /// The identifier of the entity.
        /// </value>
        public virtual string PkId
        {
            get { return RoleId; }
            set { RoleId = value; }
        }
        #endregion

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

        ///<sumary>
        /// 排序号
        ///</sumary>
        public virtual int? OrderId { get; set; }

    }
}
