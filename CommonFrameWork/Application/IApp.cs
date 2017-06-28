using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Application
{
    public interface IApp
    {
         event ApplicationStartingEventHandler Starting;
         event ApplicationStartedEventHandler Started;
         event EventHandler Stopping;

        void Start();

        void Stop();
    }


    [Serializable]
    public delegate void ApplicationStartingEventHandler(object sender, ApplicationStartingEventArgs e);

    [Serializable]
    public class ApplicationStartingEventArgs
    {
        public IEnumerable<Assembly> Assemblies { get; private set; }

        public ApplicationStartingEventArgs(IEnumerable<Assembly> assemblies)
        {
            this.Assemblies = assemblies;
        }
    }


    [Serializable]
    public delegate void ApplicationStartedEventHandler(object sender, ApplicationStartedEventArgs e);

    [Serializable]
    public class ApplicationStartedEventArgs
    {
        public IEnumerable<Assembly> Assemblies { get; private set; }

        public ApplicationStartedEventArgs(IEnumerable<Assembly> assemblies)
        {
            this.Assemblies = assemblies;
        }
    }
}
