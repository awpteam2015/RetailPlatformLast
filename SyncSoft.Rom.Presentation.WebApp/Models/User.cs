using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Models
{
    public class User
    {
        #region Properties

        public override string Id
        {
            get { return LoginId; }
        }

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
        /// 用户所属部门
        /// </summary>
        public virtual ISet<Department> Departments { get; set; }

        /// <summary>
        /// 用户所属角色
        /// </summary>
        public virtual ISet<Role> Roles { get; set; }

        /// <summary>
        /// 用户的权限
        /// </summary>
        public virtual ISet<UserPopedom> UserPopedoms { get; set; }

        /// <summary>
        /// 用户常用功能页
        /// </summary>
        public virtual ISet<ModuleFunction> ModuleFunctions { get; set; }

        /// <summary>
        /// Signar连接记录
        /// </summary>
        public virtual ISet<SignalrConnection> Connections { get; set; }
        /// <summary>
        /// 当前登录选中的部门
        /// </summary>
        public virtual Department DepartmentSelected { get; set; }

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

        #endregion
    }
}