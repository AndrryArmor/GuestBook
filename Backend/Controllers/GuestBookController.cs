using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Controllers
{
    [ApiController]
    [Route("api/guest-book/comments")]
    public class GuestBookController : ControllerBase
    {
        private readonly GuestBookService _guestBookService;

        public GuestBookController()
        {
            _guestBookService = new GuestBookService();
        }

        [HttpGet()]
        public IEnumerable<UserComment> GetAllComments()
        {
            return _guestBookService.GetUserComments();
        }

        [HttpPost("add")]
        public void AddComment([FromBody] UserComment userComment)
        {
            _guestBookService.AddUserComment(userComment);
        }
    }
}