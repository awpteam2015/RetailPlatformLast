using System.Collections.Generic;
using CommonFrameWork.Application;
using SyncSoft.Rom.Application.Dto.PermissionManager;

namespace SyncSoft.Rom.Application.ServiceContracts
{
    public interface IPermissionService
    {
        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <returns></returns>
        List<MenuDto> GetMenuList();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        AppProcessResult Login(LoginDto dto);

        TestDto Test(LoginDto dto);

        ///// <summary>
        ///// 获取登录账号的门店信息
        ///// </summary>
        ///// <param name="loginId"></param>
        ///// <returns></returns>
        //AppProcessResult GetDepartmentList(string loginId);
    }
}
