using System;
using CommonFrameWork.Extensions.NHibernate;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;
using SyncSoft.Rom.Domain.Core.OrderManager.Repositories;
using SyncSoft.Rom.Domain.Core.TestManager.Model;
using SyncSoft.Rom.Domain.Core.TestManager.Repositories;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.Repositories.TestManager
{
    public class TableMainRepository: NHibernateRepository<int, TableMain>, ITableMainRepository
    {
      
    }
}
