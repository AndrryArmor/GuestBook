namespace GuestBook.Application.Repositories
{
    public interface IUnitOfWork
    {
        IUserCommentRepository UserCommentRepository { get; }

        void SaveChanges();
    }
}
