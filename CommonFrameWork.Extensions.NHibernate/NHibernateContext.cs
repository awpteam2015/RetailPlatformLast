using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Specifications;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;

namespace CommonFrameWork.Extensions.NHibernate
{
    /// <summary>
    /// Represents the extension method provider for IQueryable{T} interface.
    /// </summary>
    internal static class QueryableExtender
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IFutureValue<TResult> ToFutureValue<TSource, TResult>(this IQueryable<TSource> source,
            Expression<Func<IQueryable<TSource>, TResult>> selector)
            where TResult : struct
        {
            var provider = (INhQueryProvider)source.Provider;
            var method = ((MethodCallExpression)selector.Body).Method;
            var expression = Expression.Call(null, method, source.Expression);
            return (IFutureValue<TResult>)provider.ExecuteFuture(expression);
        }
    }

    /// <summary>
    /// Represents the repository context which supports NHibernate implementation.
    /// </summary>
    public class NHibernateContext : RepositoryContext, INHibernateContext
    {


        #region Private Fields
        //private readonly DatabaseSessionFactory databaseSessionFactory;
        private ISession session = null;
        private readonly ISessionFactory sessionFactory = null;
        private ITransaction transaction;

        public ISession Session
        {
            get
            {
                // EnsureSession();
                if (session == null)
                {
                    this.session = this.sessionFactory.OpenSession();
                    return this.session;
                }
                return session;
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateContext"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public NHibernateContext(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }
        #endregion

        #region Private Methods
        private void EnsureSession()
        {

            if (this.session == null || !this.session.IsOpen)
            {
                this.session = this.sessionFactory.OpenSession();
                this.transaction = this.session.BeginTransaction();
            }
            else
            {
                if (this.transaction == null || !this.transaction.IsActive)
                {
                    this.transaction = this.session.BeginTransaction();
                }
            }

        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">A <see cref="System.Boolean"/> value which indicates whether
        /// the object should be disposed explicitly.</param>
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                    transaction = null;
                }
                if (session != null)
                {
                    session.Dispose();
                    session = null;
                }
            }
            base.Dispose(disposing);
        }

        public new void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Registers a new object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        public override void RegisterNew(object obj)
        {
            EnsureSession();
            session.Save(obj);
            this.Commit();
        }
        /// <summary>
        /// Registers a deleted object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        public override void RegisterDeleted(object obj)
        {
            EnsureSession();
            session.Delete(obj);
            this.Commit();
        }
        /// <summary>
        /// Registers a modified object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        public override void RegisterModified(object obj)
        {
            EnsureSession();
            session.Update(obj);
            this.Commit();
        }

        #endregion

        #region IUnitOfWork Members
        /// <summary>
        /// Gets a <see cref="System.Boolean"/> value which indicates
        /// whether the Unit of Work was successfully committed.
        /// </summary>
        public override bool Committed
        {
            get
            {
                return transaction != null &&
                    transaction.WasCommitted;
            }
            protected set { }
        }
        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public override void Commit(bool timely = false)
        {
            EnsureSession();

            var sysTransactionCount = CallContext.GetData("SYS_TransactionCount");
            if (sysTransactionCount == null || sysTransactionCount.ToString() == "0")
            {
                transaction.Commit();
            }
        }


        /// <summary>
        /// Commits the transaction asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> object which propagates notification that operations should be canceled.</param>
        /// <returns>
        /// The task that performs the commit operation.
        /// </returns>
        public override Task CommitAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rollback the transaction.
        /// </summary>
        public override void Rollback()
        {
            EnsureSession();
            transaction.Rollback();
        }

        #endregion


        #region INHibernateContext Members

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TAggregateRoot GetByKey<TKey, TAggregateRoot>(object key)
            where TAggregateRoot : class, IAggregateRoot<TKey>
        {
            var result = (TAggregateRoot)Session.Get(typeof(TAggregateRoot), key);
            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <param name="wherePredicate"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public IQueryable<TAggregateRoot> FindAll<TKey, TAggregateRoot>(
            Expression<Func<TAggregateRoot, bool>> wherePredicate,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            OrderBy sortOrder) where TAggregateRoot : class, IAggregateRoot<TKey>
        {
            IQueryable<TAggregateRoot> result = null;
            var query = Session.Query<TAggregateRoot>().Where(wherePredicate);
            switch (sortOrder)
            {
                case OrderBy.Ascending:
                    if (sortPredicate != null) result = query.OrderBy(sortPredicate);
                    break;
                case OrderBy.Descending:
                    if (sortPredicate != null) result = query.OrderByDescending(sortPredicate);
                    break;
                default:
                    result = query;
                    break;
            }
            return result;
        }

        public IQueryable<TAggregateRoot> FindAllAndFetch<TKey, TAggregateRoot>(
         Expression<Func<TAggregateRoot, bool>> wherePredicate,
         Expression<Func<TAggregateRoot, dynamic>> fetchPredicate
        ) where TAggregateRoot : class, IAggregateRoot<TKey>
        {
            IQueryable<TAggregateRoot> result = null;

            var query = Session.Query<TAggregateRoot>();
            if (fetchPredicate != null)
            {
                query = query.Fetch(fetchPredicate);
            }

            if (wherePredicate != null)
            {
                query = query.Where(wherePredicate);
            }
            result = query;
            return result;
        }


        public PagedResult<TAggregateRoot> FindAll<TKey, TAggregateRoot>(
            Expression<Func<TAggregateRoot, bool>> wherePredicate,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize) where TAggregateRoot : class, IAggregateRoot<TKey>
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "The pageNumber is one-based and should be larger than zero.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "The pageSize is one-based and should be larger than zero.");
            if (sortPredicate == null)
                throw new ArgumentNullException("sortPredicate");

            var query = Session.Query<TAggregateRoot>().Where(wherePredicate);

            int skip = (pageNumber - 1) * pageSize;
            int take = pageSize;
            int totalCount = 0;
            int totalPages = 0;
            List<TAggregateRoot> pagedData = null;
            PagedResult<TAggregateRoot> result = null;

            switch (sortOrder)
            {
                case OrderBy.Ascending:
                    totalCount = query.ToFutureValue(x => x.Count()).Value;
                    totalPages = (totalCount + pageSize - 1) / pageSize;
                    pagedData = query.OrderBy(sortPredicate).Skip(skip).Take(take).ToFuture().ToList();
                    result = new PagedResult<TAggregateRoot>(totalCount, totalPages, pageSize, pageNumber, pagedData);
                    break;
                case OrderBy.Descending:
                    totalCount = query.ToFutureValue(x => x.Count()).Value;
                    totalPages = (totalCount + pageSize - 1) / pageSize;
                    pagedData = query.OrderByDescending(sortPredicate).Skip(skip).Take(take).ToFuture().ToList();
                    result = new PagedResult<TAggregateRoot>(totalCount, totalPages, pageSize, pageNumber, pagedData);
                    break;
                default:
                    break;

            }
            return result;
        }


        public TAggregateRoot Find<TKey, TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> wherePredicate) where TAggregateRoot : class, IAggregateRoot<TKey>
        {
            var result = Session.Query<TAggregateRoot>().Where(wherePredicate).FirstOrDefault();
            return result;
        }

        #endregion
    }
}
