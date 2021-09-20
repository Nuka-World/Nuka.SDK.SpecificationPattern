using System;
using System.Linq.Expressions;

namespace Nuka.SDK.SpecificationPattern
{
    public class Or<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public Or(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> SpecificationExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T));
                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(
                        Expression.Invoke(_left.SpecificationExpression, objParam),
                        Expression.Invoke(_right.SpecificationExpression, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}