using GuestBook.Domain;
using GuestBook.Persistence.Data;

namespace GuestBook.Application
{
    public class GuestBookService : IGuestBookService
    {
        private readonly GuestBookDbContext _guestBookDbContext;

        public GuestBookService(GuestBookDbContext guestBookDbContext)
        {
            _guestBookDbContext = guestBookDbContext;
        }

        public IEnumerable<UserComment> GetUserComments()
        {
            return _guestBookDbContext.UserComments;
        }

        public void AddUserComment(UserComment userComment)
        {
            userComment.Id = default;
            userComment.PublicationDate = default;
            _guestBookDbContext.Add(userComment);
            _guestBookDbContext.SaveChanges();
        }
    }
}
