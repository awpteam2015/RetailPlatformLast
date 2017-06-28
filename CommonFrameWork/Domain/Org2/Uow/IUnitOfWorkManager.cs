using System.Transactions;

namespace CommonFrameWork.Domain.Uow
{
    /// <summary>
    /// Unit of work manager.
    /// IUnitOfWorkManager目的是提供一个简洁的IUnitOfWork管理对象，而IUnitOfWork则提供了整个工作单元需要的所有控制（Begin、SaveChanges、Complete、Dispose）。而具体应该如何保证一个线程共用一个工作单元，如何获取当前的工作单元，则由ICurrentUnitOfWorkProvider进行管控
    /// </summary>
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// Gets currently active unit of work (or null if not exists).
        /// </summary>
        IActiveUnitOfWork Current { get; }

        /// <summary>
        /// Begins a new unit of work.
        /// </summary>
        /// <returns>A handle to be able to complete the unit of work</returns>
        IUnitOfWorkCompleteHandle Begin();

        /// <summary>
        /// Begins a new unit of work.
        /// </summary>
        /// <returns>A handle to be able to complete the unit of work</returns>
        IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope);

        /// <summary>
        /// Begins a new unit of work.
        /// </summary>
        /// <returns>A handle to be able to complete the unit of work</returns>
        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}
