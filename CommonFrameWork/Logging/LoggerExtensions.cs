using System.Threading.Tasks;

namespace CommonFrameWork.Logging
{
    public static class LoggerExtensions
    {
      
        #region -  Info  -

        public static async Task InfoAsync(this ILogger logger, object msg)
        {
            await Task.Run(() => logger.Info(msg)).ConfigureAwait(false);
        }

        public static async Task InfoAsync(this ILogger logger, object msg, System.Exception exception)
        {
            await Task.Run(() => logger.Info(msg, exception)).ConfigureAwait(false);
        }

        public static async Task InfoFormatAsync(this ILogger logger, string format, params object[] args)
        {
            await Task.Run(() => logger.InfoFormat(format, args)).ConfigureAwait(false);
        }

        #endregion
      
        #region -  Debug  -

        public static async Task DebugAsync(this ILogger logger, object msg)
        {
            await Task.Run(() => logger.Debug(msg)).ConfigureAwait(false);
        }

        public static async Task DebugAsync(this ILogger logger, object msg, System.Exception exception)
        {
            await Task.Run(() => logger.Debug(msg, exception)).ConfigureAwait(false);
        }

        public static async Task DebugFormatAsync(this ILogger logger, string format, params object[] args)
        {
            await Task.Run(() => logger.DebugFormat(format, args)).ConfigureAwait(false);
        }

        #endregion
      
        #region -  Warn  -

        public static async Task WarnAsync(this ILogger logger, object msg)
        {
            await Task.Run(() => logger.Warn(msg)).ConfigureAwait(false);
        }

        public static async Task WarnAsync(this ILogger logger, object msg, System.Exception exception)
        {
            await Task.Run(() => logger.Warn(msg, exception)).ConfigureAwait(false);
        }

        public static async Task WarnFormatAsync(this ILogger logger, string format, params object[] args)
        {
            await Task.Run(() => logger.WarnFormat(format, args)).ConfigureAwait(false);
        }

        #endregion
      
        #region -  Error  -

        public static async Task ErrorAsync(this ILogger logger, object msg)
        {
            await Task.Run(() => logger.Error(msg)).ConfigureAwait(false);
        }

        public static async Task ErrorAsync(this ILogger logger, object msg, System.Exception exception)
        {
            await Task.Run(() => logger.Error(msg, exception)).ConfigureAwait(false);
        }

        public static async Task ErrorFormatAsync(this ILogger logger, string format, params object[] args)
        {
            await Task.Run(() => logger.ErrorFormat(format, args)).ConfigureAwait(false);
        }

        #endregion
      
        #region -  Fatal  -

        public static async Task FatalAsync(this ILogger logger, object msg)
        {
            await Task.Run(() => logger.Fatal(msg)).ConfigureAwait(false);
        }

        public static async Task FatalAsync(this ILogger logger, object msg, System.Exception exception)
        {
            await Task.Run(() => logger.Fatal(msg, exception)).ConfigureAwait(false);
        }

        public static async Task FatalFormatAsync(this ILogger logger, string format, params object[] args)
        {
            await Task.Run(() => logger.FatalFormat(format, args)).ConfigureAwait(false);
        }

        #endregion
    }
}
