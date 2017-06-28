using System;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Extensions.NHibernate;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;
using SyncSoft.Rom.Domain.Core.OrderManager.Repositories;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.Repositories.OrderManager
{
    public class OrderMainRepository: NHibernateRepository<String, OrderMain>, IOrderMainRepository
    {
      
    }
}
