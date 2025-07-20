using SharingPicture.Models;

namespace SharingPicture.Repositories
{
    public interface IPictureRepository
    {
        IQueryable<Picture> GetPicturesWithIncludes();
    }
}
