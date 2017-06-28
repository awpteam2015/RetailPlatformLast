using System.IO;

namespace CommonFrameWork.Application
{
    /// <summary>
    /// 自建宿主的抽象类
    /// </summary>
    public abstract class HostBase
    {
      
        #region -  Start  -

        public virtual void Start()
        {
            try
            {
                DoStart();
            }
            catch (System.Exception ex)
            {
                File.WriteAllText("C:\\" + this.GetType().FullName + ".log", ex.ToString());
                throw ex;
            }
        }

        protected abstract void DoStart();

        #endregion
       

        #region -  Stop  -

        public virtual void Stop()
        {
            try
            {
               // Engine.Stop();
            }
            catch (System.Exception ex)
            {
                File.WriteAllText("C:\\" + this.GetType().FullName + ".log", ex.ToString());
                throw ex;
            }
        }

        #endregion
    }
}
