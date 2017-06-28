using System;

namespace CommonFrameWork.Bus.Local.Model
{
    [Serializable]
    public abstract class LocalEvent : LocalMessage, ICommand
    {
        protected  MessageDispatchModeEnum DispatchMode
        {
            get { return MessageDispatchModeEnum.Local; }
        }

        public LocalEvent()
            : base()
        { }

        public LocalEvent(Guid correlationId)
            : base(correlationId)
        { }
    }
}
