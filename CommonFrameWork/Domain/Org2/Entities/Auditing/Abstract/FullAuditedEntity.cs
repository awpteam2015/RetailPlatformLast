using System;
using CommonFrameWork.Domain.Entities.Auditing.Interface;
using CommonFrameWork.Domain.Entities.Component;

namespace CommonFrameWork.Domain.Entities.Auditing.Abstract
{
    public abstract class FullAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, IFullAudited
    {

        public virtual DateTime? CreationTime { get; set; }

        public string LastModifierUserId { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }

        public string DeleterUserId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }

        #region Implementation of IHasCreationTime

        DateTime IHasCreationTime.CreationTime { get; set; }

        #endregion

        #region Implementation of ICreationAudited

        public string CreatorUserId { get; set; }

        #endregion

        #region Implementation of ISoftDelete

        public bool IsDeleted { get; set; }

        #endregion
    }
}
