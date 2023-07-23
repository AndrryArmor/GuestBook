namespace GuestBook.Application.ResponseModels
{
    public record GetUserCommentsResponse(string UserName, DateTime PublicationDate, string Comment);
}
