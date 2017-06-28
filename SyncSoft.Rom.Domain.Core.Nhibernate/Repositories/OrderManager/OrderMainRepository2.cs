using System;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Extensions.NHibernate;
using Project.Domain.Core.OrderManager.PersistentObject;
using Project.Domain.Core.OrderManager.Repositories;

namespace Project.Domain.Core.Nhibernate.Repositories.OrderManager
{
    public class OrderMainRepository2: NHibernateRepository<String,OrderMain2>, IOrderMainRepository2
    {
        public OrderMainRepository2(IRepositoryContext context)
            : base(context)
        {
            
        }
    }
}
