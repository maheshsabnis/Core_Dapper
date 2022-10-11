using Core_Dapper.Models;

namespace Core_Dapper.Services
{
    public interface IServiceRepository<TEntity, in TPk> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<bool> DeleteAsync(TPk id);
    }
}
