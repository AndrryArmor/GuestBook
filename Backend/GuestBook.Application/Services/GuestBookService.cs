using GuestBook.Application.Repositories;
using GuestBook.Application.RequestModels;
using GuestBook.Application.ResponseModels;
using GuestBook.Domain.Entities;

namespace GuestBook.Application.Services
{
    public class GuestBookService : IGuestBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GetUserCommentsResponse> GetUserComments()
        {
            return _unitOfWork.UserCommentRepository.GetAll()
                .Select(uc => new GetUserCommentsResponse(uc.UserName, uc.PublicationDate, uc.Comment)); 
        }

        public void CreateUserComment(CreateUserCommentRequest userComment)
        {
            _unitOfWork.UserCommentRepository.Create(new UserComment()
            {
                UserName = userComment.UserName,
                Comment = userComment.Comment
            });
            _unitOfWork.SaveChanges();
        }
    }
}
