using SharingPicture.Models;
using SharingPicture.Repositories;

namespace SharingPicture.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repo;

        public AlbumService(IAlbumRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Album>> GetAllAlbumsAsync()
            => _repo.GetAllAsync();

        public Task<Album?> GetAlbumByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task CreateAlbumAsync(string name, string? description, int userId)
        {
            var album = new Album
            {
                Name = name,
                Description = description,
                UserId = userId
            };
            return _repo.CreateAsync(album);
        }

        public Task AddPictureToAlbumAsync(int albumId, int pictureId)
            => _repo.AddPictureAsync(albumId, pictureId);

        public Task DeleteAlbumAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
