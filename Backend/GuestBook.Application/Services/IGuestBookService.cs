using GuestBook.Domain.Entities;

namespace GuestBook.Application.Services
{
    public interface IGuestBookService
    {
        void AddUserComment(UserComment userComment);
        IEnumerable<UserComment> GetUserComments();
    }
}