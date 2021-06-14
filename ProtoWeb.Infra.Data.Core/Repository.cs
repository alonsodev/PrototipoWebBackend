using ProtoWeb.Domain.Core;
using ProtoWeb.Domain.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Core
{
    public class Repository<TEntity> : IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public TEntity Get(string id)
        {
            return _entities.Find(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _entities.CountAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public async Task<List<TEntity>> FindAsync(ISpecification<TEntity> spec)
        {
            return await _entities.Where(spec.SpecExpression).ToListAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public TEntity SingleOrDefault(ISpecification<TEntity> spec)
        {
            return _entities.SingleOrDefault(spec.SpecExpression);
        }

        public async Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> spec)
        {
            return await _entities.SingleOrDefaultAsync(spec.SpecExpression);
        }

        public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            return await _entities.FirstOrDefaultAsync(spec.SpecExpression);
        }

        public IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount,
            Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            if (ascending)
            {
                return _entities.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return _entities.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }

        public async Task<List<TEntity>> GetPagedAsync<KProperty>(int pageIndex, int pageCount,
            Expression<Func<TEntity, bool>> whereExpression,
            Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            if (ascending)
            {
                return await _entities.Where(whereExpression).OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount).ToListAsync();
            }
            else
            {
                return await _entities.Where(whereExpression).OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount).ToListAsync();
            }
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public void Modify(TEntity item)
        {
            _entities.Update(item);
        }
    }
}
