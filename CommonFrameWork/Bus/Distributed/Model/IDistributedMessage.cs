using System;

namespace CommonFrameWork.Bus.Distributed.Model
{
    public interface IDistributedMessage : IMessage
    {
        CQRSIdentity Identity { get; }

        void SetContext(Guid correlationId, CQRSIdentity identity); 

        void SetIdentity(CQRSIdentity identity);
    }

}
