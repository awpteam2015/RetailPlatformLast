namespace CommonFrameWork.Domain.Services.Dto
{


    public class ResultInfo<TResult> where TResult : class
    {
        public bool Success { get; set; }

        /// <summary>
        /// The actual result object of ajax request.
        /// It is set if <see cref="Success"/> is true.
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// Error details (Must and only set if <see cref="Success"/> is false).
        /// </summary>
        public ErrorInfo Error { get; set; }
    }
}
