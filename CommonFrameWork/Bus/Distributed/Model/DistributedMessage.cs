using System;

namespace CommonFrameWork.Bus.Distributed.Model
{
    [Serializable]
    public abstract class DistributedMessage : IDistributedMessage
    {
        public CQRSIdentity Identity { get; private set; }         

        public Guid CorrelationId { get; private set; }

        public MessageDispatchModeEnum MessageDispatchModeEnum
        {
            get
            {
                return MessageDispatchModeEnum.DistributedSend;
            }
        }

        public DistributedMessage()
            : this(Guid.NewGuid(), new CQRSIdentity())
        {
        }

        public DistributedMessage(Guid correlationId)
            : this(correlationId, new CQRSIdentity())
        {
            
        }

        public DistributedMessage(Guid correlationId, CQRSIdentity identity)
        {
            this.CorrelationId = correlationId;
            this.Identity = identity;
        }

 

        public void SetContext(Guid correlationId, CQRSIdentity identity)   
        {
            SetCorrelationId(correlationId);
            SetIdentity(identity);
        }

        public void SetIdentity(CQRSIdentity identity) 
        {
            this.Identity = identity;
        }

        private void SetCorrelationId(Guid correlationId)
        {
            this.CorrelationId = correlationId;
        }
    }
}
