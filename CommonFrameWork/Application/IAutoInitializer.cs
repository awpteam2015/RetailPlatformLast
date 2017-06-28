using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Application
{
    /// <summary>
    /// 需要自动初始化的接口
    /// </summary>
    public interface IAutoInitializer
    {
        void Init(IEnumerable<Assembly> assemblies);
    }
}
