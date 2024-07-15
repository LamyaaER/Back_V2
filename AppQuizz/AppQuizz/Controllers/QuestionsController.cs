using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppQuizz.Data;
using AppQuizz.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppQuizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var questions = _context.Questions.Include(q => q.Technology).Include(q => q.Quiz);
            return View(await questions.ToListAsync());
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Technology)
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: api/Questions/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,TypeResponse,ComplexityLevel,TechnologyId,QuizId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Name", question.TechnologyId);
            ViewData["QuizId"] = new SelectList(_context.Quizs, "Id", "Title", question.QuizId);
            return View(question);
        }

        // PUT: api/Questions/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,TypeResponse,ComplexityLevel,TechnologyId,QuizId")] Question question)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != question.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Name", question.TechnologyId);
            ViewData["QuizId"] = new SelectList(_context.Quizs, "Id", "Title", question.QuizId);
            return View(question);
        }

        // DELETE: api/Questions/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Technology)
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: api/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
