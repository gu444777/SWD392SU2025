using Microsoft.AspNetCore.Mvc;
using SharingPicture.Models;
using SharingPicture.Services;

namespace SharingPicture.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _service;

        public AlbumController(IAlbumService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _service.GetAllAlbumsAsync();
            return View(albums);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("Name", "Album name cannot be blank");
                return View();
            }

            try
            {
                int userId = 1;
                await _service.CreateAlbumAsync(name, description, userId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Create album failed: {ex.Message}");
                return View();
            }
        }

        public async Task<IActionResult> AddPicture(int id)
        {
            var album = await _service.GetAlbumByIdAsync(id);
            ViewBag.Pictures = new List<Picture>();
            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> AddPicture(int albumId, int pictureId)
        {
            await _service.AddPictureToAlbumAsync(albumId, pictureId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var album = await _service.GetAlbumByIdAsync(id);
            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAlbumAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
