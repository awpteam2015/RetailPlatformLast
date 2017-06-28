using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSoft.Rom.Presentation.WebApp.Models
{
    public class UserInfoVm
    {
        /// <summary>
        /// 
        /// </summary>
        public string LoginId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string NickName { get; set; }
    }
}