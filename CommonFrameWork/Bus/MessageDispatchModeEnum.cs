using System;

namespace CommonFrameWork.Bus
{
    /// <summary>
    /// 消息分发方式
    /// </summary>
    [Flags]
    public enum MessageDispatchModeEnum
    {
        /// <summary>
        /// 分布式发布订阅
        /// </summary>
        DistributedPublish,
        /// <summary>
        /// 分布式发送命令模式
        /// </summary>
        DistributedSend,
        /// <summary>
        /// 分布式请求响应
        /// </summary>
        DistributedRequest,
        /// <summary>
        /// 本地消息
        /// </summary>
        Local,
    }
}
