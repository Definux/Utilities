using System;
using System.Linq.Expressions;
using Definux.Utilities.Functions.Helpers;

namespace Definux.Utilities.Functions
{
    /// <summary>
    /// Functions for expressions.
    /// </summary>
    public static class ExpressionFunctions
    {
        /// <summary>
        /// Creates an expressions with OR conditional operation.
        /// </summary>
        /// <typeparam name="T">Type of the entity for expression.</typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> OrElse<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Expression<Func<T, bool>> combined = Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    left.Body,
                    new ExpressionParameterReplacer(right.Parameters, left.Parameters).Visit(right.Body)), left.Parameters);

            return combined;
        }

        /// <summary>
        /// Creates an expressions with AND conditional operation.
        /// </summary>
        /// <typeparam name="T">Type of the entity for expression.</typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> AndAlso<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Expression<Func<T, bool>> combined = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    left.Body,
                    new ExpressionParameterReplacer(right.Parameters, left.Parameters).Visit(right.Body)), left.Parameters);

            return combined;
        }
    }
}
