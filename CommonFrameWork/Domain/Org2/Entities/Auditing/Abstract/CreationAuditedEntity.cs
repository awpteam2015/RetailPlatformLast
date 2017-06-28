using System;
using CommonFrameWork.Domain.Entities.Auditing.Interface;
using CommonFrameWork.Domain.Entities.Component;

namespace CommonFrameWork.Domain.Entities.Auditing.Abstract
{
    [Serializable]
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited
    {
        public virtual string CreatorUserId { get; set; }

        public virtual DateTime CreationTime { get; set; }
    }



}
