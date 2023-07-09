using GuestBook.Data;

namespace GuestBook
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
            _guestBookDbContext.Add(userComment);
            _guestBookDbContext.SaveChanges();
        }
    }
}
