using Core.Entities;

namespace Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        T? GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}