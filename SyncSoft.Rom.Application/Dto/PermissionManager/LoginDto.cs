using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoft.Rom.Application.Dto.PermissionManager
{
    /// <summary>
    /// 登录实体
    /// </summary>
    public class LoginDto
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
