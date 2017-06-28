

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Specifications;

namespace CommonFrameWork.Extensions.NHibernate
{
    /// <summary>
    /// Represents that the implemented classes are NHibernate contexts.
    /// </summary>
    public interface INHibernateContext : IRepositoryContext
    {
        #region Methods
        TAggregateRoot GetByKey<TKey, TAggregateRoot>(object key) where TAggregateRoot : class, IAggregateRoot<TKey>;

        IQueryable<TAggregateRoot> FindAll<TKey, TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder)
            where TAggregateRoot : class, IAggregateRoot<TKey>;

        PagedResult<TAggregateRoot> FindAll<TKey, TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize)
            where TAggregateRoot : class, IAggregateRoot<TKey>;

        TAggregateRoot Find<TKey, TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> wherePredicate)
            where TAggregateRoot : class, IAggregateRoot<TKey>;

        IQueryable<TAggregateRoot> FindAllAndFetch<TKey, TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> fetchPredicate)
          where TAggregateRoot : class, IAggregateRoot<TKey>;
        #endregion
    }
}
