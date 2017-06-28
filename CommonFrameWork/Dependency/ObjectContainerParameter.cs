using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Dependency
{
   public class ObjectContainerParameter
    {
       public string Name { get; set; }

        /// <summary>
        /// The value of the parameter.
        /// 
        /// </summary>
        public object Value { get; set; }
    }
}
