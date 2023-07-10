namespace GuestBook
{
    public interface IGuestBookService
    {
        void AddUserComment(UserComment userComment);
        IEnumerable<UserComment> GetUserComments();
    }
}