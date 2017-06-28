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
    public class CommonFrameExtensionsException : System.Exception
    {
        #region Ctor

        public CommonFrameExtensionsException() : base() { }

        public CommonFrameExtensionsException(string message) : base(message) { }

        public CommonFrameExtensionsException(string message, System.Exception innerException) : base(message, innerException) { }

        public CommonFrameExtensionsException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
