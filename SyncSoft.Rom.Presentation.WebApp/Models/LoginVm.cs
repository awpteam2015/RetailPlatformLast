using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Models
{
    public class LoginVm
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginId { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 当前选中部门
        /// </summary>
        public string SelectDepartmentCode { get; set; }
    }
}