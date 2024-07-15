using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppQuizz.Data;
using AppQuizz.Models;

namespace AppQuizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Technologies
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technologies.ToListAsync());
        }

        // GET: api/Technologies/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await _context.Technologies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        // POST: api/Technologies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technology);
        }

        // PUT: api/Technologies/Edit/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Technology technology)
        {
            if (id != technology.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnologyExists(technology.Id))
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
            return View(technology);
        }

        // DELETE: api/Technologies/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await _context.Technologies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        // POST: api/Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technology = await _context.Technologies.FindAsync(id);
            _context.Technologies.Remove(technology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnologyExists(int id)
        {
            return _context.Technologies.Any(e => e.Id == id);
        }
    }
}
