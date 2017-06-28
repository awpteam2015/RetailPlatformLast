using System;
using System.Collections.Generic;
using CommonFrameWork.Domain.Repositories;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Repositories
{

    public interface IUserRepository : IRepository<String, User>
    {
        IList<string> GetUserFunctionList(string userId);

        IList<UserDepartmentView> GetUserDepartmentView(string loginId);
    }
}
