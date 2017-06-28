using System;
using CommonFrameWork.Dependency;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Logging;
using SyncSoft.Rom.Application.ServiceContracts;
using SyncSoft.Rom.Domain.Core.OrderManager.Services;

namespace SyncSoft.Rom.Application.Implementation.OrderManager
{
    public class OrderServiceImpl : IOrderService
    {
        private readonly IOrderDomainService _orderDomainService;

        public OrderServiceImpl(IOrderDomainService _orderDomainService)
        {
            this._orderDomainService = _orderDomainService;
        }

        public void Add()
        {
            
          

        }


        public void delete()
        {
            _orderDomainService.delete();
        }

    }
}
