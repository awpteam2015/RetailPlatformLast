using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommonFrameWork.DataMap;

namespace CommonFrameWork.Extensions.AutoMapper
{
   public class DataMapperProvider: IDataMapperProvider
    {
       #region Implementation of IDataMapperProvider

       public void Init(IList<DataMapParamter> list)
       {
            Mapper.Initialize(cfg =>
            {
                list.ToList().ForEach(p =>
                {
                    cfg.CreateMap(p.Source,p.Destination).PreserveReferences();
                });
            });
        }

        public TDestination Map<TDestination>(object source)
        {
            TDestination rs = Mapper.Map<TDestination>(source);
            return rs;
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            TDestination rs = Mapper.Map<TSource, TDestination>(source, destination);
            return rs;
        }

        #endregion
    }
}
