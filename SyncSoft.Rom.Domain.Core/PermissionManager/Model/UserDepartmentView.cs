using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    public class UserDepartmentView
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public int Rank { get; set; }

    }
}
