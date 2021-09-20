using System;
using System.Linq.Expressions;

namespace Nuka.SDK.SpecificationModel
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecificationExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}