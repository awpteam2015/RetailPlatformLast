using System.Threading.Tasks;

namespace CommonFrameWork.Bus.Distributed
{
    public interface IDistributedHandler<TMessage>
        where TMessage : class, IMessage
    {
        Task<string> HandleAsync(TMessage msg);
    }
}