using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Exception
{
    public class ConfigException : CommonFrameException
    {
        #region Ctor
 
        public ConfigException() : base() { }

        public ConfigException(string message) : base(message) { }

        public ConfigException(string message, System.Exception innerException) : base(message, innerException) { }

        public ConfigException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
