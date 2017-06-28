using System;
using System.Collections.Generic;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.OrderManager.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderMain : IAggregateRoot<String>
    {
        #region Implementation of IEntity<Guid>

        /// <summary>
        /// 
        /// </summary>
        public virtual string PkId { get; set; }

        public virtual string CustomerId { get; set; }

        public virtual ISet<OrderMainDetail> OrderMainDetailList { get; set; }

        #endregion
    }
}
