namespace GuestBook.Domain.Entities
{
    public class UserComment : Entity
    {
        public string UserName { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}