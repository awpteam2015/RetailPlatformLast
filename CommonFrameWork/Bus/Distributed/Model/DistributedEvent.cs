using System;

namespace CommonFrameWork.Bus.Distributed.Model
{

    [Serializable]
    public abstract class DistributedEvent : DistributedMessage, ICommand
    {
        public DistributedEvent()
            : base()
        { }

        public DistributedEvent(Guid correlationId)
            : base(correlationId)
        { }
    }
}
