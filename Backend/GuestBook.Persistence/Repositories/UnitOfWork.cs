using GuestBook.Application.Repositories;
using GuestBook.Persistence.Contexts;

namespace GuestBook.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly GuestBookDbContext _dbContext;

        public UnitOfWork(GuestBookDbContext dbContext, IUserCommentRepository userCommentRepository)
        {
            _dbContext = dbContext;
            UserCommentRepository = userCommentRepository;
        }

        public IUserCommentRepository UserCommentRepository { get; }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
