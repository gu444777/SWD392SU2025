using SharingPicture.Models;

namespace SharingPicture.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAllAlbumsAsync();
        Task<Album?> GetAlbumByIdAsync(int id);
        Task CreateAlbumAsync(string name, string? description, int userId);
        Task AddPictureToAlbumAsync(int albumId, int pictureId);
        Task DeleteAlbumAsync(int id);
    }
}
