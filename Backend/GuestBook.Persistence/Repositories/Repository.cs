using GuestBook.Application.Exceptions;
using GuestBook.Application.Repositories;
using GuestBook.Domain.Entities;
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

        public virtual void Create(T entity)
        {
            _entities.Add(entity);
        }

        public virtual T GetById(int id)
        {
            return _entities.Find(id) ?? throw new EntityNotFoundException(id, typeof(T));
        }

        public virtual void Update(T entity)
        {
            _entities.Update(entity);
        }

        public virtual void Delete(int id)
        {
            var entityToDelete = _entities.Find(id);
            if (entityToDelete != null)
            {
                _entities.Remove(entityToDelete);
            }
            else
            {
                throw new EntityNotFoundException(id, typeof(T));
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _entities;
        }
    }
}
