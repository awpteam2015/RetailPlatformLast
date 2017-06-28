using System;
using System.Runtime.Remoting.Messaging;
using CommonFrameWork.Dependency;
using CommonFrameWork.Domain.Repositories;

namespace SyncSoft.Rom.Domain.Core.Trans
{
    public class TransactionHelper : IDisposable
    {

        public static TransactionHelper BeginTransaction()
        {
            var sysTransactionCount = CallContext.GetData("SYS_TransactionCount");
            if (sysTransactionCount == null)
            {
                sysTransactionCount = 1;
            }
            else
            {
                sysTransactionCount = int.Parse(sysTransactionCount.ToString()) + 1;
            }
            CallContext.SetData("SYS_TransactionCount", sysTransactionCount);
            return new TransactionHelper();
        }


        public void Commit()
        {
            var sysTransactionCount = CallContext.GetData("SYS_TransactionCount");
            if (sysTransactionCount == null)
            {
                sysTransactionCount = 0;
            }
            else
            {
                sysTransactionCount = int.Parse(sysTransactionCount.ToString()) - 1;
            }
            CallContext.SetData("SYS_TransactionCount", sysTransactionCount);

            if (sysTransactionCount == null || sysTransactionCount.ToString() == "0")
            {
                var context = CallContext.GetData("SYS_Context") as IRepositoryContext;
                context?.Commit();
            }
        }

        public void Rollback()
        {
            var context = CallContext.GetData("SYS_Context") as IRepositoryContext;
            context?.Rollback();
        }


        #region Implementation of IDisposable

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
        public void Dispose()
        {
           // CallContext.SetData("SYS_TransactionCount", 0);
        }

        #endregion
    }
}
