namespace GuestBook
{
    public class UserComment
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Comment { get; set; }
    }
}