namespace Devsulab.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(Guid id);
    }
}