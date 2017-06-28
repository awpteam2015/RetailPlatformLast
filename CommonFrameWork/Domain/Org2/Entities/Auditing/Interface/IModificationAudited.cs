using System;

namespace CommonFrameWork.Domain.Entities.Auditing.Interface
{
    public interface IModificationAudited
    {
        string LastModifierUserId { get; set; }

        DateTime? LastModificationTime { get; set; }

    }
}
