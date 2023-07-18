using GuestBook.Domain.Entities;

namespace GuestBook.Application.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
