using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null,
                                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        Task<TEntity> GetByIDAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);
    }
}
