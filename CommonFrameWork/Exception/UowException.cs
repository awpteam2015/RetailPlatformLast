
using System;
using System.Runtime.InteropServices;

namespace CommonFrameWork.Exception
{
    /// <summary>
    /// Represents errors that occur in the repository of Apworks framework.
    /// </summary>
    [Serializable]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(_Exception))]
    public class UowException : CommonFrameException
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <c>RepositoryException</c> class.
        /// </summary>
        public UowException() : base() { }
        /// <summary>
        /// Initializes a new instance of the <c>RepositoryException</c> class with the specified
        /// error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UowException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <c>RepositoryException</c> class with the specified
        /// error message and the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The inner exception that is the cause of this exception.</param>
        public UowException(string message, System.Exception innerException) : base(message, innerException) { }
        /// <summary>
        /// Initializes a new instance of the <c>RepositoryException</c> class with the specified
        /// string formatter and the arguments that are used for formatting the message which
        /// describes the error.
        /// </summary>
        /// <param name="format">The string formatter which is used for formatting the error message.</param>
        /// <param name="args">The arguments that are used by the formatter to build the error message.</param>
        public UowException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
