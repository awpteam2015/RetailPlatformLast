using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Exception
{
    public class DomainException : CommonFrameException
    {
        #region Ctor
 
        public DomainException() : base() { }

        public DomainException(string message) : base(message) { }

        public DomainException(string message, System.Exception innerException) : base(message, innerException) { }

        public DomainException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
