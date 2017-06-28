

using System;
using CommonFrameWork.Domain.Uow;

namespace CommonFrameWork.Domain.Repositories
{
    /// <summary>
    /// Represents that the implemented classes are repository transaction contexts.
    /// </summary>
    public interface IRepositoryContext : IUnitOfWork
    {
        /// <summary>
        /// Gets the unique-identifier of the repository context.
        /// </summary>
        Guid ID { get; }

        bool IsTrans { get; set; }

        /// <summary>
        /// Registers a new object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        void RegisterNew(object obj);
        /// <summary>
        /// Registers a modified object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        void RegisterModified(object obj);
        /// <summary>
        /// Registers a deleted object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        void RegisterDeleted(object obj);


        void Dispose(bool disposing);

        void Dispose();
    }

}
