using System;
using CommonFrameWork.Domain.Entities.Auditing.Interface;
using CommonFrameWork.Domain.Entities.Component;

namespace CommonFrameWork.Domain.Entities.Auditing.Abstract
{
    public abstract class AuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, IAudited
    {
        public virtual string CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual string LastModifierUserId { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }

   
    }
}
