using GuestBook.Domain;

namespace GuestBook.Application
{
    public interface IGuestBookService
    {
        void AddUserComment(UserComment userComment);
        IEnumerable<UserComment> GetUserComments();
    }
}