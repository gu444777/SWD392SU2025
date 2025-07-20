using SharingPicture.Models;

namespace SharingPicture.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> AddCommentAsync(Comment comment);
    }
}
