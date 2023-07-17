using GuestBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserCommentRepository UserCommentRepository { get; }

        void SaveChanges();
    }
}
