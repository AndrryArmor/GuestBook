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
        public ActionResult<IEnumerable<GetUserCommentsResponse>> GetAllComments()
        {
            try
            {
                return _guestBookService.GetUserComments().ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CreateUserCommentRequest userComment)
        {
            var validator = new CreateUserCommentRequestValidator(userComment);
            if (!validator.IsRequestValid)
            {
                return BadRequest(new { Errors = validator.ValidationErrors });
            }

            try
            {
                _guestBookService.CreateUserComment(userComment);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}