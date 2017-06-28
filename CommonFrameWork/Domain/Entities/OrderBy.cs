

namespace CommonFrameWork.Domain.Entities
{
    /// <summary>
    /// Represents the sorting style.
    /// </summary>
    public enum OrderBy
    {
        /// <summary>
        /// Indicates that the sorting style is not specified.
        /// </summary>
        Unspecified = -1,
        /// <summary>
        /// Indicates an ascending sorting.
        /// </summary>
        Ascending = 0,
        /// <summary>
        /// Indicates a descending sorting.
        /// </summary>
        Descending = 1
    }
}
