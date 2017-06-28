using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.DataMap
{
    /// <summary>
    /// 
    /// </summary>
    public class DataMapParamter
    {
        public DataMapParamter(Type source, Type destination)
        {
            Source = source;
            Destination = destination;
        }

        public Type Source { get; set; }

        public Type Destination { get; set; }

    }
}
