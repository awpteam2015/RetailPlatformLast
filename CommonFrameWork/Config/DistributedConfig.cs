using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Config
{
    public class DistributedConfig
    {
        public DistributedConfig()
        {
            SendingQueues=new List<SendingQueue>();
            ReceivingQueues=new List<ReceivingQueue>();
        }

        public string HostUri { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public List<SendingQueue> SendingQueues { get; set; }

        public List<ReceivingQueue> ReceivingQueues { get; set; }

    }

    public class SendingQueue
    {
        public string Message { get; set; }

        public string ToQueue { get; set; }
    }

    public class ReceivingQueue
    {
        //public string Message { get; set; }

        public string FromQueue { get; set; }

        /// <summary>
        /// consume处理的程序集
        /// </summary>
        public string Filter { get; set; }
    }

}
