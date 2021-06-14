using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProtoWeb.Domain.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}
