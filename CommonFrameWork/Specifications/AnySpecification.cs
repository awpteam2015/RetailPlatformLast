using System;
using System.Linq.Expressions;

namespace CommonFrameWork.Specifications
{
    public sealed class AnySpecification<T> : Specification<T>
    {
        #region Public Methods
        /// <summary>
        /// Gets the LINQ expression which represents the current specification.
        /// </summary>
        /// <returns>The LINQ expression.</returns>
        public override Expression<Func<T, bool>> GetExpression()
        {
            return o => true;
        }
        #endregion
    }
}
