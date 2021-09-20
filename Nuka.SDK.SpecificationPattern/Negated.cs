using System;
using System.Linq.Expressions;

namespace Nuka.SDK.SpecificationPattern
{
    public class Negated<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _inner;

        public Negated(ISpecification<T> inner)
        {
            _inner = inner;
        }

        public override Expression<Func<T, bool>> SpecificationExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T));
                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.Not(
                        Expression.Invoke(this._inner.SpecificationExpression, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}