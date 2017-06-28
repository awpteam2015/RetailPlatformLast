using System;
using CommonFrameWork.Domain.Entities.Auditing.Abstract;

namespace CommonFrameWork.Domain.Entities
{
    /// <summary>
    /// Add Update
    /// </summary>
     [Serializable]
    public abstract class AuditedEntity : AuditedEntity<int>
    {

    }
}
