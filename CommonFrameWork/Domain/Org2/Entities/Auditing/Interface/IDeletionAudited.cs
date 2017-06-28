using System;
using CommonFrameWork.Domain.Entities.Component;

namespace CommonFrameWork.Domain.Entities.Auditing.Interface
{
    public interface IDeletionAudited : ISoftDelete
    {
        string DeleterUserId { get; set; }
        DateTime? DeletionTime { get; set; }
    }
}
