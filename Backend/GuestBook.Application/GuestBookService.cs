using GuestBook.Application.Interfaces.Repositories;
using GuestBook.Domain;

namespace GuestBook.Application
{
    public class GuestBookService : IGuestBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserComment> GetUserComments()
        {
            return _unitOfWork.UserCommentRepository.GetAll();
        }

        public void AddUserComment(UserComment userComment)
        {
            userComment.Id = default;
            userComment.PublicationDate = default;
            _unitOfWork.UserCommentRepository.Add(userComment);
            _unitOfWork.SaveChanges();
        }
    }
}
