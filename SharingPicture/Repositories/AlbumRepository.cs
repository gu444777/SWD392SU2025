using Microsoft.EntityFrameworkCore;
using SharingPicture.Models;

namespace SharingPicture.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly Swd392su2025Context _context;

        public AlbumRepository(Swd392su2025Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums.Include(a => a.User).ToListAsync();
        }

        public async Task<Album?> GetByIdAsync(int id)
        {
            return await _context.Albums
                .Include(a => a.Pictures)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateAsync(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
        }

        public async Task AddPictureAsync(int albumId, int pictureId)
        {
            var album = await _context.Albums.Include(a => a.Pictures).FirstOrDefaultAsync(a => a.Id == albumId);
            var picture = await _context.Pictures.FindAsync(pictureId);

            if (album != null && picture != null && !album.Pictures.Contains(picture))
            {
                album.Pictures.Add(picture);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }
        }
    }
}
