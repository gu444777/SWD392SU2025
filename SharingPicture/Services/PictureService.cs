using Microsoft.EntityFrameworkCore;
using SharingPicture.Models;
using SharingPicture.Repositories;

namespace SharingPicture.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _repo;
        public PictureService(IPictureRepository repo) => _repo = repo;

        public async Task<(List<Picture> Items, int TotalItems)> GetPicturesAsync(
            string searchString, string searchBy, string sortOrder, int page, int pageSize)
        {
            var pictures = _repo.GetPicturesWithIncludes();

            // Search
            if (!string.IsNullOrEmpty(searchString))
            {
                if (searchBy == "author")
                    pictures = pictures.Where(p => p.User.Username.Contains(searchString));
                else
                    pictures = pictures.Where(p => p.Title.Contains(searchString));
            }

            // Sorting
            switch (sortOrder)
            {
                case "uploaded_desc":
                    pictures = pictures.OrderByDescending(p => p.UploadedAt);
                    break;
                case "comments":
                    pictures = pictures.OrderBy(p => p.Comments.Count);
                    break;
                case "comments_desc":
                    pictures = pictures.OrderByDescending(p => p.Comments.Count);
                    break;
                case "likes":
                    pictures = pictures.OrderBy(p => p.PictureLikes.Count);
                    break;
                case "likes_desc":
                    pictures = pictures.OrderByDescending(p => p.PictureLikes.Count);
                    break;
                default:
                    pictures = pictures.OrderBy(p => p.UploadedAt);
                    break;
            }

            int totalItems = await pictures.CountAsync();
            var items = await pictures.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalItems);
        }
    }
}
