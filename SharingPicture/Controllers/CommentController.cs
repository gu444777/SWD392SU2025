using Microsoft.AspNetCore.Mvc;
using SharingPicture.Services;
using SharingPicture.Models;

namespace SharingPicture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddComment([FromBody] AddCommentRequest request)
        {
            var comment = await _commentService.AddCommentAsync(request.Content, request.PictureId, request.UserId);
            return Ok(comment);
        }
    }

    public class AddCommentRequest
    {
        public string Content { get; set; } = null!;
        public int PictureId { get; set; }
        public int UserId { get; set; }
    }
}
