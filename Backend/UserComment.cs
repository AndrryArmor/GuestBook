using System.ComponentModel.DataAnnotations;

namespace GuestBook
{
    public class UserComment
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Comment { get; set; }
    }
}