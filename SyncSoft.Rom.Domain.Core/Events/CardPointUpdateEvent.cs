using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Bus.Local;
using CommonFrameWork.Bus.Local.Model;

namespace SyncSoft.Rom.Domain.Core.Events
{
    public class CardPointUpdateEvent : LocalEvent
    {
        public string OrderNo { get; set; }

        public int Points { get; set; }
    }
}
