using System;
using System.Reflection;
using System.Threading.Tasks;
using CommonFrameWork.Dependency;

namespace CommonFrameWork.Bus.Local
{
    public interface ILocalMessageBus
    {
        Task<string> ExecuteAsync<TMessage>(TMessage msg)
            where TMessage : class, IMessage;

       string ExecuteSync<TMessage>(TMessage msg)
           where TMessage : class, IMessage;
    }

    public class LocalMessageBus : ILocalMessageBus
    {
      
        #region -  Field(s)  -

        private static readonly Type HANDERTYPE = typeof(ILocalHandler<>);

        #endregion
      
        #region -  Excute  -

        public Task<string> ExecuteAsync<TMessage>(TMessage msg)
            where TMessage : class, IMessage
        {
            var handerType = HANDERTYPE.MakeGenericType(msg.GetType());  
            var handler = ObjectContainer.Resolve(handerType);

            var task = (Task<string>)handerType.InvokeMember("HandleAsync", BindingFlags.InvokeMethod, null, handler, new object[] { msg });
            return task;
        }

        public string ExecuteSync<TMessage>(TMessage msg) where TMessage : class, IMessage
        {
            var handerType = HANDERTYPE.MakeGenericType(msg.GetType());
            var handler = ObjectContainer.Resolve(handerType);

            var result = (string)handerType.InvokeMember("HandleSync", BindingFlags.InvokeMethod, null, handler, new object[] { msg });
            return result;
        }

        #endregion
    }
}
