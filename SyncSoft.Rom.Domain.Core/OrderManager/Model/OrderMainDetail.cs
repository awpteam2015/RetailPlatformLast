using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.OrderManager.Model
{
    public class OrderMainDetail : IEntity<int>
    {
        #region Implementation of IEntity<int>

        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>
        /// The identifier of the entity.
        /// </value>
        public virtual int PkId { get; set; }

        #endregion

        public virtual string OrderNo { get; set; }

        public virtual string ProductName { get; set; }
    }
}
