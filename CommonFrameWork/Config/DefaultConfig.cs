using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Config
{
    public class DefaultConfig : IConfigSource
    {

        public DefaultConfig()
        {
            Config=new CommonFrameWorkConfig();
        }

        public CommonFrameWorkConfig Config { get; set; }

    }
}
