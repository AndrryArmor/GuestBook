using GuestBook.Application.RequestModels;
using GuestBook.Application.ResponseModels;
using GuestBook.Application.Services;
using GuestBook.Application.Validators;
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
        public IEnumerable<GetUserCommentsResponse> GetAllComments()
        {
            return _guestBookService.GetUserComments();
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CreateUserCommentRequest userComment)
        {
            var validator = new CreateUserCommentRequestValidator(userComment);
            if (!validator.IsRequestValid)
            {
                return BadRequest(new { Errors = validator.ValidationErrors });
            }

            _guestBookService.CreateUserComment(userComment);
            return Ok();
        }
    }
}