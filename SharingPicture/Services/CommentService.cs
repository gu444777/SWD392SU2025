using SharingPicture.Models;
using SharingPicture.Repositories;

namespace SharingPicture.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> AddCommentAsync(string content, int pictureId, int userId)
        {
            var comment = new Comment
            {
                Content = content,
                PictureId = pictureId,
                UserId = userId
            };

            return await _commentRepository.AddCommentAsync(comment);
        }
    }
}
