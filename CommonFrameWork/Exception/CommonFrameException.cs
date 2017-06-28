using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Exception
{
    /// <summary>
    /// 整体框架错误
    /// </summary>
    public class CommonFrameException : System.Exception
    {
        #region Ctor

        public CommonFrameException() : base() { }

        public CommonFrameException(string message) : base(message) { }

        public CommonFrameException(string message, System.Exception innerException) : base(message, innerException) { }

        public CommonFrameException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
