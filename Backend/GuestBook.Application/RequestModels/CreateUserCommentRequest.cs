namespace GuestBook.Application.RequestModels
{
    public record CreateUserCommentRequest(string? UserName, string? Comment);
}
