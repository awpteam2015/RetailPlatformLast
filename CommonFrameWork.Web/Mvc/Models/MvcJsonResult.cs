using System;
using System.Web.Mvc;
using CommonFrameWork.Application;
using CommonFrameWork.Dependency;
using CommonFrameWork.Serialization;

namespace CommonFrameWork.Web.Mvc.Models
{
    public class MvcJsonResult : JsonResult
    {
        public MvcJsonResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }

        public MvcJsonResult(object data)
            : this()
        {
            Data = data;
        }

        /// <inheritdoc/>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                var serializeResult = ObjectContainer.Resolve<IObjectSerializer>().Serialize(Data);
                response.Write(serializeResult);
            }
        }

        public static MvcJsonResult Error()
        {
            return new MvcJsonResult(new AjaxResponse() {IsSuccess = false});
        }

        public static MvcJsonResult Success()
        {
            return new MvcJsonResult(new AjaxResponse() { IsSuccess = true });
        }

        public static MvcJsonResult Result(AppProcessResult result)
        {
            return new MvcJsonResult(new AjaxResponse() { IsSuccess = result.IsSuccess,Message = result.Message,Code = result.Code,Data = result.Data,AttachData = result.AttachData});
        }

    }

}
