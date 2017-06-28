using Autofac;

namespace CommonFrameWork.Extensions.Autofac
{
    /// <summary>
    /// 
    /// </summary>
    internal class Holder
    {
        private static readonly ContainerBuilder _containerBuilder = new ContainerBuilder();

        public static ContainerBuilder ContainerBuilder
        {
            get { return _containerBuilder; }
        }

        public static IContainer Container { get; set; }
    }
}
