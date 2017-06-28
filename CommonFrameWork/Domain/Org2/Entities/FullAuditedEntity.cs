using System;
using CommonFrameWork.Domain.Entities.Auditing.Abstract;

namespace CommonFrameWork.Domain.Entities
{
    /// <summary>
    /// Add Update Delete
    /// </summary>
    [Serializable]
    public abstract class FullAuditedEntity : FullAuditedEntity<int>
    {
    }
}
