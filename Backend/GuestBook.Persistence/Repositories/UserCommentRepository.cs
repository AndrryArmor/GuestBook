using GuestBook.Application.Interfaces.Repositories;
using GuestBook.Domain;
using GuestBook.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Persistence.Repositories
{
    public class UserCommentRepository : Repository<UserComment>, IUserCommentRepository
    {
        public UserCommentRepository(GuestBookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
