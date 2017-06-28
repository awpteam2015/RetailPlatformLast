using System;
using System.Collections.Generic;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Extensions.NHibernate;
using NHibernate;
using NHibernate.Transform;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;
using SyncSoft.Rom.Domain.Core.OrderManager.Repositories;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.Domain.Core.PermissionManager.Repositories;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.Repositories.PermissionManager
{
    public class UserRepository : NHibernateRepository<String, User>, IUserRepository
    {

        /// <summary>
        /// 获取用户有效权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<string> GetUserFunctionList(string userId)
        {
            var sql = @"select distinct functionrightid
  from(select b.functionrightid
          from pb_user_role a
          left
          join pb_rolepopedom b on a.roleid = b.roleid
         where a.loginid = '" + userId + @"'
        union all
        select a.functionrightid
          from pb_userpopedom a
         where a.loginid = '" + userId + @"'
           and a.POPEDOMVALUE = 1) a
 where a.functionrightid not in
       (select a.functionrightid
          from pb_userpopedom a
         where a.loginid = '" + userId + @"'
           and a.POPEDOMVALUE = 0)";

            var t = (NHibernateContext)NhContext;
            var returnList = t.Session.CreateSQLQuery(sql).List<string>();
            return returnList;
        }


        /// <summary>
        /// 获取用户对应的部门信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public IList<UserDepartmentView> GetUserDepartmentView(string loginId)
        {
            var sql = @"select * from pb_departmentuser a
                        left join pb_user b on a.loginid=b.loginid
                        left join pb_department c on a.departmentcode=c.departmentcode 
                        where a.loginid='" + loginId + "'";

            var t = (NHibernateContext)NhContext;
            var returnList = t.Session.CreateSQLQuery(sql)
                  .AddScalar("DepartmentCode", NHibernateUtil.String)
                .AddScalar("DepartmentName", NHibernateUtil.String)
                  .AddScalar("Rank", NHibernateUtil.Int32)
                .SetResultTransformer(Transformers.AliasToBean(typeof(UserDepartmentView))).List<UserDepartmentView>();
            return returnList;
        }




    }
}
