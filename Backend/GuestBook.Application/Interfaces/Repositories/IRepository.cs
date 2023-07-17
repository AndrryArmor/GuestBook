using GuestBook.Domain;

namespace GuestBook.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
