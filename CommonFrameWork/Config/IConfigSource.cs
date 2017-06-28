using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Config
{
    public interface IConfigSource
    {
        CommonFrameWorkConfig Config { get; }
    }
}
