using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Domain.Entities;

namespace SyncSoft.Rom.Domain.Core.TestManager.Model
{
    public class TableMain : IAggregateRoot<Int32>
    {
        public virtual int PkId { get; set; }


        public virtual string AAName { get; set; }

    }
}
