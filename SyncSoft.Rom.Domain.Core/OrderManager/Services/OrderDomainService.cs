using System;
using System.Collections.Generic;
using System.Linq;
using CommonFrameWork.Bus;
using CommonFrameWork.Dependency;
using CommonFrameWork.Domain.Repositories;
using SyncSoft.Rom.Domain.Core.Events;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;
using SyncSoft.Rom.Domain.Core.OrderManager.Repositories;

namespace SyncSoft.Rom.Domain.Core.OrderManager.Services
{
    /// <summary>
    /// 订单领域
    /// </summary>
    public class OrderDomainService : IOrderDomainService
    {
        #region Private Fields
        private readonly IRepositoryContext _repositoryContext;
        private readonly IOrderMainRepository _orderMainRepository;
        //private readonly IOrderMainDetailRepository _orderMainDetailRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个新的<c>DomainService</c>类型的实例。
        /// </summary>
        /// <param name="context">仓储上下文。</param>
        public OrderDomainService(IRepositoryContext context)
        {
            var parameter = new ObjectContainerParameter()
            {
                Name = "context",
                Value = context
            };

            _repositoryContext = context;
          //  _orderMainDetailRepository = ObjectContainer.Resolve<IOrderMainDetailRepository>(parameter); ;
            _orderMainRepository = ObjectContainer.Resolve<IOrderMainRepository>(parameter);
            // _orderMainRepository2 = ObjectContainer.Resolve<IOrderMainRepository2>(parameter);
        }
        #endregion


        public void Test()
        {
            try
            {
                Add();
                int.Parse("xx");
                Add();
                _repositoryContext.Commit(true);
            }
            catch (Exception e)
            {

                throw;
            }

        }


        public void delete()
        {
            try
            {
                var model = _orderMainRepository.GetByKey("4f48009d-3eed-418d-9341-51d74550c49b");
                model.OrderMainDetailList.ToList().ForEach(p =>
                {
                   // _orderMainDetailRepository.Remove(p);
                });
                _repositoryContext.Commit(true);
            }
            catch (Exception e)
            {

                throw;
            }

        }


        public String Add()
        {
            // ObjectContainer.Resolve<IMessageDispatcher>().Dispatch(new GetCustomerEvent());
            var ordermain = new OrderMain() { PkId = Guid.NewGuid().ToString(), CustomerId = "顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多" };
            ordermain.OrderMainDetailList = new HashSet<OrderMainDetail>()
            {
                new OrderMainDetail()
                {   OrderNo = ordermain.PkId,
                    ProductName = "顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多顶顶顶顶顶顶多"
                }
            };
            _orderMainRepository.Add(ordermain);
            //_orderMainDetailRepository.Add(new OrderMainDetail()
            //{
            //    ProductName = "2222"
            //});
            // _repositoryContext.Commit();
            //_repositoryContext.Dispose();
            return "";
        }

        public void Delete()
        {
            var orderMain = _orderMainRepository.GetByKey("10");
            _orderMainRepository.Remove(orderMain);
            _repositoryContext.Commit();
            _repositoryContext.Dispose();
        }

        public void Update()
        {
            var orderMain = _orderMainRepository.GetByKey("10");
            orderMain.CustomerId = "xxx333";
            _orderMainRepository.Update(orderMain);
            _repositoryContext.Commit();

        }


        public OrderMain Get()
        {
            return _orderMainRepository.GetByKey("10");
        }

        public void TriggerOtherDomain()
        {
            ObjectContainer.Resolve<IMessageDispatcher>().Dispatch(new CardPointUpdateEvent()
            );
        }


    }



}
