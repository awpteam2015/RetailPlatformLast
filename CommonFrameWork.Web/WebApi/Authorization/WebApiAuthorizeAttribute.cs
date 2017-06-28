using System;
using System.Web;
using System.Web.Mvc;


namespace CommonFrameWork.Web.WebApi.Authorization
{
    public abstract class WebApiAuthorizeAttribute : AuthorizeAttribute
    {
        private AuthorizationContext FilterContext { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("HttpContext");
            }
            //if (!httpContext.User.Identity.IsAuthenticated)
            //{
            //    return false;
            //}

            var t = httpContext.Request["Author_UserId"].ToString();


            var areaName = "";
            if (FilterContext.RouteData.DataTokens.ContainsKey("area"))
            {
                areaName = FilterContext.RouteData.DataTokens["area"].ToString();
            }
            string controllerName = FilterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = FilterContext.ActionDescriptor.ActionName;

            return Valid(areaName, controllerName, actionName);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            FilterContext = filterContext;
            base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// 权限验证处理
        /// </summary>
        /// <param name="areaName"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public abstract bool Valid(string areaName, string controllerName, string actionName);

        /// <summary>
        /// 未取得权限的处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            base.HandleUnauthorizedRequest(filterContext);

            var returnUrl = string.Empty;
            var referrerUrl = filterContext.HttpContext.Request.UrlReferrer;
            if (referrerUrl != null)
            {
                returnUrl = HttpUtility.UrlEncode(referrerUrl.PathAndQuery);
            }

            var result = new JsonResult() { };
            result.Data = new
            {
                status = "notauthorized",
                msg = "您的授权过期。",
                loginUrl = "/account/login?ReturnUrl=" + returnUrl
            };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            filterContext.Result = result;
        }
    }
}
