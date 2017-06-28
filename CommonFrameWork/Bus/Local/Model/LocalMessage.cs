using System;

namespace CommonFrameWork.Bus.Local.Model
{
    [Serializable]
    public abstract class LocalMessage : ILocalMessage
    {
        public Guid CorrelationId { get; private set; }

        public MessageDispatchModeEnum MessageDispatchModeEnum {
            get { return MessageDispatchModeEnum.Local; }
        }

        public LocalMessage()
            : this(Guid.NewGuid())
        {
        }
        public LocalMessage(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

    }
}
