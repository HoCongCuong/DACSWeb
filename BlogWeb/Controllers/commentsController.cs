using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogWeb.Data;
using BlogWeb.Models;

namespace BlogWeb.Controllers
{
    public class commentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public commentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: comments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.comments.Include(c => c.ApplicationUser).Include(c => c.post);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.comments == null)
            {
                return NotFound();
            }

            var comment = await _context.comments
                .Include(c => c.ApplicationUser)
                .Include(c => c.post)
                .FirstOrDefaultAsync(m => m.postId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: comments/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["postId"] = new SelectList(_context.Posts, "Id", "Id");
            return View();
        }

        // POST: comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("postId,ApplicationUserId,CreatedDate,cmt")] comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", comment.ApplicationUserId);
            ViewData["postId"] = new SelectList(_context.Posts, "Id", "Id", comment.postId);
            return View(comment);
        }

        // GET: comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.comments == null)
            {
                return NotFound();
            }

            var comment = await _context.comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", comment.ApplicationUserId);
            ViewData["postId"] = new SelectList(_context.Posts, "Id", "Id", comment.postId);
            return View(comment);
        }

        // POST: comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("postId,ApplicationUserId,CreatedDate,cmt")] comment comment)
        {
            if (id != comment.postId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!commentExists(comment.postId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", comment.ApplicationUserId);
            ViewData["postId"] = new SelectList(_context.Posts, "Id", "Id", comment.postId);
            return View(comment);
        }

        // GET: comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.comments == null)
            {
                return NotFound();
            }

            var comment = await _context.comments
                .Include(c => c.ApplicationUser)
                .Include(c => c.post)
                .FirstOrDefaultAsync(m => m.postId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.comments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.comments'  is null.");
            }
            var comment = await _context.comments.FindAsync(id);
            if (comment != null)
            {
                _context.comments.Remove(comment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool commentExists(int? id)
        {
          return (_context.comments?.Any(e => e.postId == id)).GetValueOrDefault();
        }
    }
}
