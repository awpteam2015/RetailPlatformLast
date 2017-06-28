using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using CommonFrameWork.Dependency;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Exception;
using CommonFrameWork.Specifications;
using NHibernate.Transform;

namespace CommonFrameWork.Extensions.NHibernate
{

    public class NHibernateRepository<TKey, TAggregateRoot> : Repository<TKey, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        #region Private Fields
        public INHibernateContext NhContext
        {
            get
            {
                return GetContext();
            }
        }
        #endregion

        public static INHibernateContext GetContext()
        {
            INHibernateContext context;
            var objContext = CallContext.GetData("SYS_Context");
            if (objContext != null)
            {
                context = objContext as INHibernateContext;
            }
            else
            {
                context = (ObjectContainer.Resolve<IRepositoryContext>()) as INHibernateContext;
                CallContext.SetData("SYS_Context", context);
            }

            if (context == null)
                throw new RepositoryException("The provided context type is invalid. NHibernateRepository requires an instance of NHibernateContext to be initialized.");
            return context;
        }

        #region Overrides of Repository<TKey,TAggregateRoot>

        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            NhContext.RegisterNew(aggregateRoot);
        }

        protected override void DoRemove(TAggregateRoot aggregateRoot)
        {
            NhContext.RegisterDeleted(aggregateRoot);
        }

        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
            NhContext.RegisterModified(aggregateRoot);
        }

        protected override bool DoExists(Expression<Func<TAggregateRoot, bool>> wherePredicate)
        {
            return true;
        }

        protected override TAggregateRoot DoGetByKey(TKey key)
        {
            return NhContext.GetByKey<TKey, TAggregateRoot>(key);
        }

        protected override IQueryable<TAggregateRoot> DoFindAll()
        {
            return NhContext.FindAll<TKey, TAggregateRoot>(null, null, OrderBy.Unspecified);
        }

        protected override IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder)
        {
            return NhContext.FindAll<TKey, TAggregateRoot>(null, sortPredicate, sortOrder);
        }

        protected override PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize)
        {
            return NhContext.FindAll<TKey, TAggregateRoot>(null, sortPredicate, OrderBy.Unspecified, pageNumber, pageSize);
        }

        protected override IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate)
        {
            return NhContext.FindAll<TKey, TAggregateRoot>(wherePredicate, null, OrderBy.Unspecified);
        }

        protected override IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder)
        {
            return NhContext.FindAll<TKey, TAggregateRoot>(wherePredicate, sortPredicate, sortOrder);
        }

        protected override PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, OrderBy sortOrder, int pageNumber, int pageSize)
        {
            return NhContext.FindAll<TKey, TAggregateRoot>(wherePredicate, sortPredicate, sortOrder, pageNumber, pageSize);
        }

        protected override IQueryable<TAggregateRoot> DoFindAllAndFetch(Expression<Func<TAggregateRoot, bool>> wherePredicate, Expression<Func<TAggregateRoot, dynamic>> fetchPredicate)
        {
            return NhContext.FindAllAndFetch<TKey, TAggregateRoot>(wherePredicate, fetchPredicate);
        }

        #endregion
    }


    public class NHibernateRepository<TAggregateRoot> : NHibernateRepository<Guid, TAggregateRoot>,
                                                        IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {

    }
}
