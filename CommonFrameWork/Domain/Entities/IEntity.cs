
using System;

namespace CommonFrameWork.Domain.Entities
{
    /// <summary>
    /// Represents that the implemented classes are domain entities.
    /// </summary>
    /// <typeparam name="TKey">The type of the key of the entity.</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>
        /// The identifier of the entity.
        /// </value>
        TKey PkId { get; set; }
    }

    /// <summary>
    /// Represents that the implemented classes are domain entities.
    /// </summary>
    public interface IEntity : IEntity<Guid>
    {

    }
}
