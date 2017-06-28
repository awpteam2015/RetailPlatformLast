using System.Threading.Tasks;
using CommonFrameWork.Bus.Distributed;
using CommonFrameWork.Bus.Local;
using CommonFrameWork.CommUtils;
using CommonFrameWork.Dependency;

namespace CommonFrameWork.Bus
{

    /// <summary>
    /// 消息分发器
    /// </summary>
    public class MessageDispatcher : IMessageDispatcher
    {

        #region -  Field(s)  -
        private readonly ILocalMessageBus _localMessageBus;
        #endregion


        #region -  Constructor(s)  -

        public MessageDispatcher(ILocalMessageBus localMessageBus)
        {
            _localMessageBus = localMessageBus;

        }

        #endregion

        #region -  Dispatch  -

        
        public string Dispatch<TMessage>(TMessage msg)
            where TMessage : class, IMessage
        {
  
            var msgCode = "";
            switch (msg.MessageDispatchModeEnum)
            {
                case MessageDispatchModeEnum.DistributedSend:
                    AsyncUtils.RunSync(ObjectContainer.Resolve<IDistributedMessageBus>().SendAsync(msg));
                    break;
                case MessageDispatchModeEnum.DistributedPublish:
                    AsyncUtils.RunSync(ObjectContainer.Resolve<IDistributedMessageBus>().PublishAsync(msg));
                    break;
                case MessageDispatchModeEnum.DistributedRequest:
                    msgCode = AsyncUtils.RunSync(ObjectContainer.Resolve<IDistributedMessageBus>().RequestAsync(msg));
                    break;
                case MessageDispatchModeEnum.Local:
                    try
                    {
                        msgCode = _localMessageBus.ExecuteSync(msg);
                    }
                    catch (System.Exception ex)
                    {
                        msgCode = ex.GetBaseException().Message;
                    }
                    break;
                default:
                    msgCode = "未实现该类型的消息分发";
                    break;
            }

            return msgCode;

        }

        public async Task<string> DispatchAsync<TMessage>(TMessage msg)
           where TMessage : class, IMessage
        {
            var dispatchMode = msg.MessageDispatchModeEnum;
            if (dispatchMode == MessageDispatchModeEnum.DistributedSend)
            {
                await ObjectContainer.Resolve<IDistributedMessageBus>().SendAsync(msg).ConfigureAwait(false);
            }
            else if (dispatchMode == MessageDispatchModeEnum.DistributedPublish)
            {

                await ObjectContainer.Resolve<IDistributedMessageBus>().PublishAsync(msg).ConfigureAwait(false);
            }
            else if (dispatchMode == MessageDispatchModeEnum.DistributedRequest)
            {
                var msgCode = await ObjectContainer.Resolve<IDistributedMessageBus>().RequestAsync(msg).ConfigureAwait(false);
                return msgCode;
            }
            else if (dispatchMode == MessageDispatchModeEnum.Local)
            {
                string msgCode;
                try
                {
                    msgCode = await _localMessageBus.ExecuteAsync(msg).ConfigureAwait(false);
                }
                catch (System.Exception ex)
                {
                    msgCode = ex.GetBaseException().Message;
                }

                return msgCode;
            }
            return "";
        }


        #endregion
    }



}
