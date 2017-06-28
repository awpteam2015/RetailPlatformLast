using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Bus
{
    /// <summary>
    /// 消息分发器
    /// </summary>
    public interface IMessageDispatcher
    {
        /// <summary>
        /// 同步发送消息
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        string Dispatch<TMessage>(TMessage msg)
            where TMessage : class, IMessage;

        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task<string> DispatchAsync<TMessage>(TMessage msg)
            where TMessage : class, IMessage;

    }
}
