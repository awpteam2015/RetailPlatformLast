using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    public class User : IAggregateRoot<String>
    {
        #region Implementation of IEntity<string>

        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>
        /// The identifier of the entity.
        /// </value>
        public virtual string PkId { get; set; }

        #endregion

        /// <summary>
        /// 用户登录Id
        /// </summary>
        public virtual string LoginId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 分机号
        /// </summary>
        public virtual string ExtPhoneNo { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public virtual int? Disabled { get; set; }

        /// <summary>
        /// 销售顾问编码
        /// </summary>
        private string sellerCode;

        /// <summary>
        /// 销售顾问编码
        /// </summary>
        public virtual string SellerCode
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.sellerCode)) return "900000";
                return this.sellerCode;
            }
            set
            {
                this.sellerCode = value;
            }
        }

        /// <summary>
        /// 默认登录选中的部门
        /// </summary>
        public virtual string DepartmentCodeDefault { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public virtual string LoginIp { get; set; }

        /// <summary>
        /// 关联前台会员卡号
        /// </summary>
        public virtual string CardId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public virtual string JobNumber { get; set; }

        /// <summary>
        /// 成本中心代码
        /// </summary>
        public virtual string CostCenterCode { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public virtual string Position { get; set; }

        /// <summary>
        /// 职位代码
        /// </summary>
        public virtual string PositionCode { get; set; }


        #region 级联

        public virtual IList<Role> RoleList { get; set; }

        #endregion

    }
}
