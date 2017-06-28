using System.Threading.Tasks;

namespace CommonFrameWork.Bus.Local
{
    public class LocalHandler<TMessage> : ILocalHandler<TMessage> where TMessage : class, IMessage

    {

        public virtual Task<string> HandleAsync(TMessage msg)
        {
            throw new System.NotImplementedException();
        }

        public string HandleSync(TMessage msg)
        {
            throw new System.NotImplementedException();
        }
    }
}