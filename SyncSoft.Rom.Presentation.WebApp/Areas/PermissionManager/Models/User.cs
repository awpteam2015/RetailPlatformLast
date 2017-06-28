using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager.Models
{
    public class User
    {
        #region Properties

     
        /// <summary>
        /// 用户登录Id
        /// </summary>
        
        [Required(ErrorMessage = "密码不能超过20个字符")]
        public string LoginId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 分机号
        /// </summary>
        public string ExtPhoneNo { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public int? Disabled { get; set; }

        /// <summary>
        /// 销售顾问编码
        /// </summary>
        private string sellerCode;

        /// <summary>
        /// 销售顾问编码
        /// </summary>
        public string SellerCode
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
        public string DepartmentCodeDefault { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIp { get; set; }

        /// <summary>
        /// 关联前台会员卡号
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

      
        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 成本中心代码
        /// </summary>
        public string CostCenterCode { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 职位代码
        /// </summary>
        public string PositionCode { get; set; }

        #endregion
    }
}