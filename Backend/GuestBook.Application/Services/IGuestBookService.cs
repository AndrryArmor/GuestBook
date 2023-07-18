using GuestBook.Application.RequestModels;
using GuestBook.Application.ResponseModels;

namespace GuestBook.Application.Services
{
    public interface IGuestBookService
    {
        void CreateUserComment(CreateUserCommentRequest userComment);
        IEnumerable<GetUserCommentsResponse> GetUserComments();
    }
}