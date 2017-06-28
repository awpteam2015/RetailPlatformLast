using CommonFrameWork.Domain.Entities;

namespace CommonFrameWork.Domain.Repositories
{

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryOfInt<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryOfString<TEntity> : IRepository<TEntity, string> where TEntity : class, IEntity<string>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryReadOnlyOfInt<TEntity> : IRepositoryReadOnly<TEntity, int> where TEntity : class, IEntity<int>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryReadOnlyOfString<TEntity> : IRepositoryReadOnly<TEntity, string> where TEntity : class, IEntity<string>
    {

    }

}
