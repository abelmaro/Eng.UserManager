using Eng.UserManager.DataAccess.Interfaces;
using Eng.UserManager.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Eng.UserManager.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UserManagerDataContext _context;
        public Repository(UserManagerDataContext context) {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        public async Task<TEntity> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<TEntity>().Remove(entity);

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
                throw new EntityNotFoundException(id);

            return entity;
        }

        public IQueryable<TEntity> GetBaseQuery()
        {
            return _context.Set<TEntity>();
        }
    }
}
