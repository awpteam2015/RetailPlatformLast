using System.Runtime.InteropServices;
using SyncSoft.Rom.Domain.Core.OrderManager.Model;

namespace SyncSoft.Rom.Domain.Core.OrderManager.Services
{
    public interface IOrderDomainService
    {
        string Add();

        void Delete();
        void Update();
        OrderMain Get();

        void TriggerOtherDomain();

        void delete();

        void Test();
    }
}
