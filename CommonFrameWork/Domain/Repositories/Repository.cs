

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Specifications;

namespace CommonFrameWork.Domain.Repositories
{

    public abstract class Repository<TKey, TAggregateRoot> : IRepository<TKey, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {

        #region Protected Methods

        protected abstract void DoAdd(TAggregateRoot aggregateRoot);
        protected abstract void DoRemove(TAggregateRoot aggregateRoot);
        protected abstract void DoUpdate(TAggregateRoot aggregateRoot);
        protected abstract bool DoExists(Expression<Func<TAggregateRoot, bool>> wherePredicate);
        protected abstract TAggregateRoot DoGetByKey(TKey key);

        protected abstract IQueryable<TAggregateRoot> DoFindAll();

        protected abstract IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            OrderBy sortOrder);

        protected abstract PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            OrderBy sortOrder, int pageNumber, int pageSize);

        protected abstract IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate);

        protected abstract IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder);

        protected abstract PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize);

        protected abstract IQueryable<TAggregateRoot> DoFindAllAndFetch(
            Expression<Func<TAggregateRoot, bool>> wherePredicate,
            Expression<Func<TAggregateRoot, dynamic>> fetchPredicate);

        #endregion

        #region Implementation of IRepository<TKey,TAggregateRoot>

        public void Add(TAggregateRoot aggregateRoot)
        {
            this.DoAdd(aggregateRoot);
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            this.DoRemove(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            this.DoUpdate(aggregateRoot);
        }

        public bool Exists(Expression<Func<TAggregateRoot, bool>> wherePredicate)
        {
            return this.DoExists(wherePredicate);
        }

        public TAggregateRoot GetByKey(TKey key)
        {
            return this.DoGetByKey(key);
        }

        public IQueryable<TAggregateRoot> FindAll()
        {
            return this.DoFindAll();
        }

        public IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder)
        {
            return DoFindAll(sortPredicate, sortOrder);
        }

        public PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize)
        {
            return DoFindAll(sortPredicate, sortOrder, pageNumber, pageSize);
        }

        public IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate)
        {
            return DoFindAll(wherePredicate);
        }

        public IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder)
        {
            return DoFindAll(wherePredicate, sortPredicate, sortOrder);
        }

        public PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize)
        {
            return DoFindAll(wherePredicate, sortPredicate, sortOrder, pageNumber, pageSize);
        }

        public IQueryable<TAggregateRoot> FindAllAndFetch(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> fetchPredicate)
        {
            return DoFindAllAndFetch(wherePredicate, fetchPredicate);
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public abstract class Repository<TAggregateRoot> : Repository<Guid, TAggregateRoot>, IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {


    }
}
