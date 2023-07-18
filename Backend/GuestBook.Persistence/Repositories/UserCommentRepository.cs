using GuestBook.Application.Repositories;
using GuestBook.Domain.Entities;
using GuestBook.Persistence.Contexts;

namespace GuestBook.Persistence.Repositories
{
    public class UserCommentRepository : Repository<UserComment>, IUserCommentRepository
    {
        public UserCommentRepository(GuestBookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
