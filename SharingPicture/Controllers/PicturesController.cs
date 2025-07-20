using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SharingPicture.Models;
using SharingPicture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharingPicture.Controllers
{
    public class PicturesController : Controller
    {
        private readonly Swd392su2025Context _context;
        private readonly IPictureService _service;

        public PicturesController(Swd392su2025Context context, IPictureService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Pictures
        public async Task<IActionResult> Index(
        string searchString, string sortOrder, int page = 1, int pageSize = 9, string searchBy = "title")
        {
            var (items, totalItems) = await _service.GetPicturesAsync(searchString, searchBy, sortOrder, page, pageSize);

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewData["CurrentSearchBy"] = searchBy;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["UploadedSortParm"] = String.IsNullOrEmpty(sortOrder) ? "uploaded_desc" : "";
            ViewData["CommentsSortParm"] = sortOrder == "comments" ? "comments_desc" : "comments";
            ViewData["LikesSortParm"] = sortOrder == "likes" ? "likes_desc" : "likes";

            return View(items);
        }

        // GET: Pictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // GET: Pictures/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,FilePath,Description,UploadedAt,UserId")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(picture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", picture.UserId);
            return View(picture);
        }

        // GET: Pictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures.FindAsync(id);
            if (picture == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", picture.UserId);
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,FilePath,Description,UploadedAt,UserId")] Picture picture)
        {
            if (id != picture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(picture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureExists(picture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", picture.UserId);
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Pictures
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            if (picture != null)
            {
                _context.Pictures.Remove(picture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureExists(int id)
        {
            return _context.Pictures.Any(e => e.Id == id);
        }
    }
}
