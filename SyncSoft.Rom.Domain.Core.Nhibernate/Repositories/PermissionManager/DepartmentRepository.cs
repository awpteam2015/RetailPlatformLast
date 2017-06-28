using System;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Extensions.NHibernate;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;
using SyncSoft.Rom.Domain.Core.OrderManager.Repositories;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.Domain.Core.PermissionManager.Repositories;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.Repositories.PermissionManager
{
    public class DepartmentRepository : NHibernateRepository<String, Department>, IDepartmentRepository
    {
       
    }
}
