using System;

namespace CommonFrameWork.Bus.Local.Model
{
    [Serializable]
    public abstract class LocalCommand : LocalMessage, ICommand
    {
        protected  MessageDispatchModeEnum DispatchMode
        {
            get { return MessageDispatchModeEnum.Local; }
        }

        public LocalCommand()
            : base()
        { }

        public LocalCommand(Guid correlationId)
            : base(correlationId)
        { }
    }
}
