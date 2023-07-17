using GuestBook.Application.Interfaces.Repositories;
using GuestBook.Domain;
using GuestBook.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly GuestBookDbContext _dbContext;
        protected readonly DbSet<T> _entities;

        public Repository(GuestBookDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _entities.Add(entity);
        }

        public virtual T GetById(int id)
        {
            return _entities.Find(id);
        }

        public virtual void Update(T entity)
        {
            _entities.Update(entity);
        }

        public virtual void Delete(int id)
        {
            var entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _entities;
        }
    }
}
