using SharingPicture.Models;

namespace SharingPicture.Services
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(string content, int pictureId, int userId);
    }
}
