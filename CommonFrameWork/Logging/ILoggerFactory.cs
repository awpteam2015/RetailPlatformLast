using System;

namespace CommonFrameWork.Logging
{
	#region -  Interface  -

	public interface ILoggerFactory
	{
		/// <summary>Create a logger with the given logger name.
		/// </summary>
		ILogger Create(string name);
		/// <summary>Create a logger with the given type.
		/// </summary>
		ILogger Create(Type type);
		/// <summary>Create a logger with the generic type.
		/// </summary>
		ILogger Create<T>();
	}

	#endregion
}
