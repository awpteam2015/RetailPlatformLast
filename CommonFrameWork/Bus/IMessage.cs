using System;

namespace CommonFrameWork.Bus
{
    public interface IMessage
    {
        Guid CorrelationId { get; }

        MessageDispatchModeEnum MessageDispatchModeEnum { get; }
    }

}
