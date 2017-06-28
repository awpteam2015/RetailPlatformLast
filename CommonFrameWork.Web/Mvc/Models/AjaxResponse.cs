using System;

namespace CommonFrameWork.Web.Mvc.Models
{
    [Serializable]
    public class AjaxResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 结果代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误信息或者成功信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 结果实体
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// 附加的其他信息
        /// </summary>
        public string AttachData { get; set; }
    }
}
