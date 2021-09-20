using System;
using System.Linq.Expressions;

namespace Nuka.SDK.SpecificationPattern
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        private Func<T, bool> _compiledExpression;

        private Func<T, bool> CompiledExpression
        {
            get { return _compiledExpression ??= SpecificationExpression.Compile(); }
        }

        public abstract Expression<Func<T, bool>> SpecificationExpression { get; }
        
        public bool IsSatisfiedBy(T obj)
        {
            return CompiledExpression(obj);
        }
    }
}