using System;
using CommonFrameWork.Domain.Entities.Auditing.Interface;

namespace CommonFrameWork.Domain.Entities.Auditing.Abstract
{
     [Serializable]
    public abstract class ModificationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, IModificationAudited
    {
         public virtual string LastModifierUserId { get; set; }
         public virtual DateTime? LastModificationTime { get; set; }
    }

 

}
