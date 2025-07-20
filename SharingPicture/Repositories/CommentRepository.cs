using SharingPicture.Models;
using Microsoft.EntityFrameworkCore;

namespace SharingPicture.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Swd392su2025Context _context;

        public CommentRepository(Swd392su2025Context context)
        {
            _context = context;
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            comment.CreatedAt = DateTime.UtcNow;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
