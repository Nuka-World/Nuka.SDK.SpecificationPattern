using System;
using System.Linq.Expressions;

namespace Nuka.SDK.SpecificationPattern
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecificationExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}