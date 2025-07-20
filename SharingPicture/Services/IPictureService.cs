using SharingPicture.Models;

namespace SharingPicture.Services
{
    public interface IPictureService
    {
        Task<(List<Picture> Items, int TotalItems)> GetPicturesAsync(
            string searchString, string searchBy, string sortOrder, int page, int pageSize);
    }
}
