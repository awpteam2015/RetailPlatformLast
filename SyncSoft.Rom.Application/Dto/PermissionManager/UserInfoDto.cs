using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoft.Rom.Application.Dto.PermissionManager
{
    public class UserInfoDto
    {
        /// <summary>
        /// 
        /// </summary>
        public  string LoginId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string NickName { get; set; }


        public virtual string SelectDepartmentCode { get; set; }

        public virtual string SelectDepartmentName { get; set; }
    }
}
