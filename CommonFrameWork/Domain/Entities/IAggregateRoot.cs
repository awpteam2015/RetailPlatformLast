using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Domain.Entities
{
    /// <summary>
    /// Represents that the implemented classes are aggregate roots.
    /// </summary>
    /// <typeparam name="TKey">The type of the key of the aggregate root.</typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {

    }

    /// <summary>
    /// Represents that the implemented classes are aggregate roots.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<Guid>, IEntity
    {

    }
}
