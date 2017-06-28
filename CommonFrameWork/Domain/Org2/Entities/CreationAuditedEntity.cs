using System;
using CommonFrameWork.Domain.Entities.Auditing.Abstract;

namespace CommonFrameWork.Domain.Entities
{
    /// <summary>
    /// Add
    /// </summary>
     [Serializable]
    public abstract class CreationAuditedEntity : CreationAuditedEntity<int>
    {

    }

}
