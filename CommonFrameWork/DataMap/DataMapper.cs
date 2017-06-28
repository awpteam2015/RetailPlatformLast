using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.DataMap
{
    public static class DataMapper
    {
        private static readonly object _locker = new object();
        private static IDataMapperProvider _current;
        private static IList<DataMapParamter> DataMapList = new List<DataMapParamter>();

        public static void SetProvider(IDataMapperProvider container)
        {
            if (null == _current)
            {
                lock (_locker)
                {
                    if (null == _current)
                    {
                        _current = container;
                    }
                }
            }
        }

        public static void CreateMap(DataMapParamter map)
        {
            DataMapList.Add(map);
        }

        public static void CreateMap(Type source,Type destination)
        {
            DataMapList.Add(new DataMapParamter(source, destination));
        }


        public static void CreateMap(Type self)
        {
            DataMapList.Add(new DataMapParamter(self, self));
        }


        public static void Init()
        {
            _current.Init(DataMapList);
        }


        public static TDestination Map<TDestination>(object source)
        {
            TDestination rs = _current.Map<TDestination>(source);
            return rs;
        }

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            TDestination rs = _current.Map<TSource, TDestination>(source, destination);
            return rs;
        }

    }
}
