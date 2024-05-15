using Core.Entity;

namespace Core.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> GetAll();

        T? GetById(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}