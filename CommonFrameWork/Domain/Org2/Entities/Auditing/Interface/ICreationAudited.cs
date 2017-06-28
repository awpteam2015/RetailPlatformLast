using System;
using CommonFrameWork.Domain.Entities.Component;

namespace CommonFrameWork.Domain.Entities.Auditing.Interface
{
    /// <summary>
    /// 新增授权
    /// </summary>
    public interface ICreationAudited : IHasCreationTime
    {
  
        string CreatorUserId { get; set; }


    }
}
