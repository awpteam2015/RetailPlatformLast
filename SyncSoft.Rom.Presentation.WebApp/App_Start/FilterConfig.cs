using System.Web.Mvc;
using CommonFrameWork.Web.Mvc.Filter;

namespace SyncSoft.Rom.Presentation.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //filters.Add(new ErrorLoggerAttribute());
            filters.Add(new CustomExceptionAttribute());
        }
    }
}