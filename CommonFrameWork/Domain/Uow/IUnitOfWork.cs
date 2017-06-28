using System.Threading;
using System.Threading.Tasks;

namespace CommonFrameWork.Domain.Uow
{
    /// <summary>
    /// Defines a unit of work.
    /// This interface is internally used by ABP.
    /// Use <see cref="IUnitOfWorkManager.Begin()"/> to start a new unit of work.
    /// </summary>
    public interface IUnitOfWork 
    {
        /// <summary>
        /// Gets a <see cref="System.Boolean"/> value which indicates
        /// whether the Unit of Work could support Microsoft Distributed
        /// Transaction Coordinator (MS-DTC).
        /// </summary>
        bool DistributedTransactionSupported { get; }
        /// <summary>
        /// Gets a <see cref="System.Boolean"/> value which indicates
        /// whether the Unit of Work was successfully committed.
        /// </summary>
        bool Committed { get; }
        /// <summary>
        /// Commits the transaction.
        /// </summary>
        void Commit(bool timely=false);

        /// <summary>
        /// Commits the transaction asynchronously.
        /// </summary>
        /// <returns>The task that performs the commit operation.</returns>
        Task CommitAsync();

        /// <summary>
        /// Commits the transaction asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object which propagates notification that operations should be canceled.</param>
        /// <returns>The task that performs the commit operation.</returns>
        Task CommitAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Rollback the transaction.
        /// </summary>
        void Rollback();
    }
}