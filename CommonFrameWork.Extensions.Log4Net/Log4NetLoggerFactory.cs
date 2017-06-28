using System;
using CommonFrameWork.Logging;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using ILoggerFactory = CommonFrameWork.Logging.ILoggerFactory;


namespace CommonFrameWork.Extensions.Log4Net
{
	/// <summary>Log4Net based logger factory.
	/// </summary>
	public class Log4NetLoggerFactory : ILoggerFactory
	{
		/// <summary>Parameterized constructor.
		/// </summary>
		public Log4NetLoggerFactory()
		{
		    try
		    {
                var arr = XmlConfigurator.Configure();
		    }
		    catch (System.Exception e)
		    {
		        
		        throw;
		    }
	


		}
		/// <summary>Create a new Log4NetLogger instance.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ILogger Create(string name)
		{
			return new Log4NetLogger(LogManager.GetLogger(name));
		}
		/// <summary>Create a new Log4NetLogger instance.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public ILogger Create(Type type)
		{
			return new Log4NetLogger(LogManager.GetLogger(type));
		}

		/// <summary>Create a new Log4NetLogger instance.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public ILogger Create<T>()
		{
			return new Log4NetLogger(LogManager.GetLogger(typeof(T)));
		}


    }
}
