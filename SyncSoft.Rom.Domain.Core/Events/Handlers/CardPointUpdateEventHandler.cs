using System.Threading.Tasks;
using CommonFrameWork.Bus.Local;

namespace SyncSoft.Rom.Domain.Core.Events.Handlers
{
    public class CardPointUpdateEventHandler : ILocalHandler<CardPointUpdateEvent>
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
