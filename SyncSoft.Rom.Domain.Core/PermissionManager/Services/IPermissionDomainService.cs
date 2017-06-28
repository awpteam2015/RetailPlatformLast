using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Application;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Services
{
    public interface IPermissionDomainService
    {
        /// <summary>
        /// 账号登录
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        /// <param name="selectDepartmentCode"></param>
        AppProcessResult Login(string loginId, string password, string selectDepartmentCode);

        /// <summary>
        /// 获取用户对应的部门信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        AppProcessResult GetDepartmentList(string loginId);
    }
}
