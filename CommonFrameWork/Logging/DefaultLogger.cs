using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Logging
{
    public class DefaultLogger : ILogger
    {
        public void Info(object message)
        {
            Log(message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Log(args);
        }

        public void Info(object message, System.Exception exception)
        {
            Log(message);
        }

        public void Debug(object message)
        {
            Log(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Log(args);
        }

        public void Debug(object message, System.Exception exception)
        {
            Log(message);
        }

        public void Error(object message)
        {
            Log(message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Log(args);
        }

        public void Error(object message, System.Exception exception)
        {
            Log(message);
        }

        public void Warn(object message)
        {
            Log(message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Log(args);
        }

        public void Warn(object message, System.Exception exception)
        {
            Log(message);
        }

        public void Fatal(object message)
        {
            Log(message);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Log(args);
        }

        public void Fatal(object message, System.Exception exception)
        {
            Log(message);
        }

        private void Log(object logMessage)
        {
            string strPath = @"c:\log";
            if (!System.IO.File.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            strPath = strPath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(strPath) == true)
            {
                FileStream myFs = new FileStream(strPath, FileMode.Create);
                myFs.Close();
            }

            StreamWriter fs = new StreamWriter(strPath, false, System.Text.Encoding.Default);
            fs.Write(logMessage);
            //fs.Write(JsonConvert.SerializeObject(logMessage));
            fs.Close();
        }
    }
}
