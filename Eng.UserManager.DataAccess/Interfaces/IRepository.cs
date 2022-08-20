namespace Eng.UserManager.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> DeleteById(int id);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetBaseQuery();
    }
}
