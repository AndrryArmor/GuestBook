namespace GuestBook.Domain.Entities
{
    public class UserComment : Entity
    {
        public string? UserName { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Comment { get; set; }
    }
}