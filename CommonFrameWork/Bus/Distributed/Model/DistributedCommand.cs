using System;

namespace CommonFrameWork.Bus.Distributed.Model
{

    [Serializable]
    public abstract class DistributedCommand : DistributedMessage, ICommand
    {
        public DistributedCommand()
            : base()
        { }

        public DistributedCommand(Guid correlationId)
            : base(correlationId)
        { }
    }

    [Serializable]
    public class DistributedCommandResponse : DistributedMessage, ICommand
    {
        public string MessageCode { get; private set; }

        public DistributedCommandResponse(Guid correlationId, string msgCode)
            : base(correlationId)
        {
            this.MessageCode = msgCode;
        }
    }

}
