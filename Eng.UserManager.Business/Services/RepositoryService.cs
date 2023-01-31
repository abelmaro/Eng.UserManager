using Eng.UserManager.Business.Interfaces;
using Eng.UserManager.DataAccess.Interfaces;

namespace Eng.UserManager.Business.Services
{
    public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public RepositoryService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public Task<TEntity> AddAsync(TEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<TEntity> DeleteByIdAsync(int id)
        {
            return _repository.DeleteByIdAsync(id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public IQueryable<TEntity> GetBaseQuery()
        {
            return _repository.GetBaseQuery();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }
    }
}
