namespace CommonFrameWork.Application
{
    public class AppProcessResult
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

        #region
        #region Error

        /// <summary>
        /// 输错错误信息
        /// </summary>
        /// <returns></returns>
        public static AppProcessResult Error()
        {
            return new AppProcessResult()
            {
                IsSuccess = false
            };
        }
        /// <summary>
        /// 输错错误信息
        /// </summary>
        /// <param name="message">附属消息</param>
        /// <returns></returns>
        public static AppProcessResult Error(string message, int code = 500)
        {
            return new AppProcessResult()
            {
                IsSuccess = false,
                Message = message,
                Code = code
            };
        }

        #endregion

        #region Success
        /// <summary>
        /// 输出成功信息
        /// </summary>
        /// <returns></returns>
        public static AppProcessResult Success()
        {
            return new AppProcessResult()
            {
                IsSuccess = true
            };
        }
        /// <summary>
        /// 输出成功信息
        /// </summary>
        /// <param name="message">附属消息</param>
        /// <returns></returns>
        public static AppProcessResult Success(string message)
        {
            return new AppProcessResult()
            {
                IsSuccess = true,
                Message = message
            };
        }
        /// <summary>
        /// 输出成功信息
        /// </summary>
        /// <param name="data">附属数据</param>
        /// <returns></returns>
        public static AppProcessResult Success(dynamic data)
        {
            return new AppProcessResult()
            {
                IsSuccess = true,
                Code = 200,
                Data = data
            };
        }


        /// <summary>
        /// 输出成功信息
        /// </summary>
        /// <param name="data">附属数据</param>
        /// <returns></returns>
        public static AppProcessResult NormalReturn(dynamic data)
        {
            if (data == null)
            {
                return new AppProcessResult()
                {
                    IsSuccess = false,
                    Code = 200,
                    Data = data,
                    Message = "数据不存在"
                };
            }
            else
            {
                return new AppProcessResult()
                {
                    IsSuccess = true,
                    Code = 200,
                    Data = data
                };
            }
        }

        /// <summary>
        /// 输出成功信息
        /// </summary>
        /// <param name="data">附属数据</param>
        /// <param name="message">附属消息</param>
        /// <returns></returns>
        public static AppProcessResult Success(dynamic data, string message)
        {
            return new AppProcessResult()
            {
                IsSuccess = true,
                Data = data,
                Code = 200,
                Message = message
            };
        }


        /// <summary>
        /// 输出成功信息
        /// </summary>
        /// <param name="data">附属数据</param>
        /// <param name="message">附属消息</param>
        /// <param name="attachData"></param>
        /// <returns></returns>
        public static AppProcessResult Success(dynamic data, string attachData, string message)
        {
            return new AppProcessResult()
            {
                IsSuccess = true,
                Data = data,
                Code = 200,
                Message = message,
                AttachData = attachData
            };
        }

        #endregion
        #endregion
    }
}
