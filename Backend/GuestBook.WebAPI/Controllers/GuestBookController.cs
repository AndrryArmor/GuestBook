using GuestBook.Application;
using GuestBook.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/guest-book/comments")]
    public class GuestBookController : ControllerBase
    {
        private readonly IGuestBookService _guestBookService;

        public GuestBookController(IGuestBookService guestBookService)
        {
            _guestBookService = guestBookService;
        }

        [HttpGet]
        public IEnumerable<UserComment> GetAllComments()
        {
            return _guestBookService.GetUserComments();
        }

        [HttpPost]
        public void AddComment([FromBody] UserComment userComment)
        {
            _guestBookService.AddUserComment(userComment);
        }
    }
}