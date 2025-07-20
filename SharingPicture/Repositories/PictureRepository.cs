using Microsoft.EntityFrameworkCore;
using SharingPicture.Models;

namespace SharingPicture.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly Swd392su2025Context _context;
        public PictureRepository(Swd392su2025Context context) => _context = context;

        public IQueryable<Picture> GetPicturesWithIncludes()
        {
            return _context.Pictures
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Include(p => p.PictureLikes);
        }
    }
}
