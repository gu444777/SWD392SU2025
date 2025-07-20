using SharingPicture.Models;

namespace SharingPicture.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAllAsync();
        Task<Album?> GetByIdAsync(int id);
        Task CreateAsync(Album album);
        Task AddPictureAsync(int albumId, int pictureId);
        Task DeleteAsync(int id);
    }
}
