using ProtoWeb.Domain.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Domain.Core
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<int> CountAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindAsync(ISpecification<TEntity> spec);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(ISpecification<TEntity> spec);
        Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> spec);
        Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec);
        IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount,
            Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
        Task<List<TEntity>> GetPagedAsync<KProperty>(int pageIndex, int pageCount,
            Expression<Func<TEntity, bool>> whereExpression,
            Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
    }
}
