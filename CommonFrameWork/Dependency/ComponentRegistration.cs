using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Dependency
{
    public class ComponentRegistration
    {
        public ComponentRegistration( Type implType)
        {
            //ServiceType = serviceType;
            ImplementationType = implType;
        }

        public Type ServiceType { get; private set; }
        public Type ImplementationType { get; private set; }

    }
}
