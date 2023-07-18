using GuestBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Application.Repositories
{
    public interface IUserCommentRepository : IRepository<UserComment>
    {
    }
}
