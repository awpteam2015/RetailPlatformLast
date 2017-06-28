using CommonFrameWork.Bus;
using CommonFrameWork.Bus.Distributed;
using CommonFrameWork.Bus.Local;
using CommonFrameWork.Dependency;

namespace CommonFrameWork.Application
{
    public static class AppExtensions
    {
        public static IApp ConfigMessageDispatcher(this IApp step)
        {
            ObjectContainer.Register<ILocalMessageBus, LocalMessageBus>();
            ObjectContainer.Register<IMessageDispatcher, MessageDispatcher>();
            ObjectContainer.Register<IDistributedMessageBus, DistributedMessageBus>();
            
            //step.Starting += (o, e) =>
            //{
            //    ObjectContainer.Register<IMessageDispatcher, MessageDispatcher>();
            //    ObjectContainer.Register<ILocalMessageBus, LocalMessageBus>();
            //   // ObjectContainer.RegisterGeneric(typeof(ILocalHandler<>));
            //};
            return step;
        }
    }
}
