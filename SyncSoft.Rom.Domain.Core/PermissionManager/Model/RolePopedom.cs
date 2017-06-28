using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    public class RolePopedom : IEntity<String>
    {
        #region Implementation of IEntity<string>

        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>
        /// The identifier of the entity.
        /// </value>
        public string PkId { get; set; }

        #endregion
    }
}
