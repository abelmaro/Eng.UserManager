using Eng.UserManager.DataAccess.Interfaces;

namespace Eng.UserManager.Business.Interfaces
{
    public interface IRepositoryService<TEntity> : IRepository<TEntity> where TEntity : class 
    {
    }
}
