using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Logging
{
    public class DefaultLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name)
        {
           return new DefaultLogger();
        }

        public ILogger Create(Type type)
        {
            return new DefaultLogger();
        }

        public ILogger Create<T>()
        {
            return new DefaultLogger();
        }
    }
}
