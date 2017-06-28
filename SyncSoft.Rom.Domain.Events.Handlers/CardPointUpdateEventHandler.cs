using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Bus.Local;
using CommonFrameWork.Dependency;
using SyncSoft.Rom.Domain.Core.CustomerManager.Services;
using SyncSoft.Rom.Domain.Core.Events;
using SyncSoft.Rom.Domain.Core.OrderManager.Services;

namespace SyncSoft.Rom.Domain.Events.Handlers
{
    public class SendEmailEventHandler : ILocalHandler<CardPointUpdateEvent>
    {
        #region Implementation of ILocalHandler<CardPointUpdateEvent>

        public Task<string> HandleAsync(CardPointUpdateEvent msg)
        {
            // ObjectContainer.Resolve<ICustomerDomainService>().UpdatePoint();
            return null;
        }

        public string HandleSync(CardPointUpdateEvent msg)
        {
            // ObjectContainer.Resolve<ICustomerDomainService>().UpdatePoint();
            return "";
        }

        #endregion
    }
}
