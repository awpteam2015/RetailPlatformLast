using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Exception
{
    public class AppException : CommonFrameException
    {
        #region Ctor
 
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, System.Exception innerException) : base(message, innerException) { }

        public AppException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
