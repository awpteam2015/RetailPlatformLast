using System.Threading.Tasks;

namespace CommonFrameWork.Bus.Distributed
{
    public interface IDistributedMessageBus
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task SendAsync(object msg);

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task PublishAsync(object msg);

        /// <summary>
        /// 应答
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task<string> RequestAsync<TMessage>(TMessage msg)
            where TMessage : class, IMessage;
    }

    public abstract class DistributedMessageBus : IDistributedMessageBus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public abstract Task SendAsync(object msg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public abstract Task PublishAsync(object msg);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        public abstract Task<string> RequestAsync<TMessage>(TMessage msg)
            where TMessage : class, IMessage;
    }
}
