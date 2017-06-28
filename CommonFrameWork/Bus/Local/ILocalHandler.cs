using System.Threading.Tasks;

namespace CommonFrameWork.Bus.Local
{
    public interface ILocalHandler<TMessage>
        where TMessage : class, IMessage
    {
        Task<string> HandleAsync(TMessage msg);

        string HandleSync(TMessage msg);

    }
}