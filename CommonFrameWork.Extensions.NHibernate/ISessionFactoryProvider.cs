using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace CommonFrameWork.Extensions.NHibernate
{
   public interface ISessionFactoryProvider
   {
       ISessionFactory GetSessionFactory();
   }
}
