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
        public Task<TEntity> Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public Task<TEntity> DeleteById(int id)
        {
            return _repository.DeleteById(id);
        }

        public Task<List<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<TEntity> GetBaseQuery()
        {
            return _repository.GetBaseQuery();
        }

        public Task<TEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }
    }
}
