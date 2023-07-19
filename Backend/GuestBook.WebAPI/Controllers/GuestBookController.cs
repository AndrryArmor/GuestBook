using GuestBook.Application.RequestModels;
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
        public IActionResult GetAllComments()
        {
            try
            {
                var userComments = _guestBookService.GetUserComments();
                return Ok(userComments);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CreateUserCommentRequest userComment)
        {
            try
            {
                var validator = new CreateUserCommentRequestValidator(userComment);
                if (!validator.IsRequestValid)
                {
                    return BadRequest(new { Errors = validator.ValidationErrors });
                }

                _guestBookService.CreateUserComment(userComment);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}