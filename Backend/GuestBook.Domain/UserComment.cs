using System.ComponentModel.DataAnnotations;

namespace GuestBook.Domain
{
    public class UserComment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Your name must not be empty.")]
        [MinLength(3, ErrorMessage = $"Your name must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = $"Your name must not exceed 100 characters.")]
        public string? UserName { get; set; }

        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Comment must not be empty.")]
        [MinLength(10, ErrorMessage = "Comment must be at least 10 characters long.")]
        [MaxLength(4000, ErrorMessage = "Comment must not exceed 4000 characters.")]
        public string? Comment { get; set; }
    }
}