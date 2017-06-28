namespace CommonFrameWork.Domain.Uow
{
    /// <summary>
    /// Defines a unit of work.
    /// This interface is internally used by ABP.
    /// Use <see cref="IUnitOfWorkManager.Begin()"/> to start a new unit of work.
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        /// 唯一的标识ID
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 外层工作单元
        /// </summary>
        IUnitOfWork Outer { get; set; }

        /// <summary>
        /// 开始 unit of work的一些配置UnitOfWorkOptions，主要是事务的级别，超时时间，配置文件等
        /// </summary>
        /// <param name="options">Unit of work options</param>
        void Begin(UnitOfWorkOptions options);
    }
}